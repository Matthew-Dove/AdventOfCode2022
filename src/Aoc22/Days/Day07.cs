namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/7
**/
public class Day07
{
    public List<StdOut> Parse(string input)
    {
        var stdout = input.Replace("\r", string.Empty).Split('\n');
        var cmds = new List<StdOut>();

        for (int i = 0; i < stdout.Length; i++)
        {
            if (stdout[i].Equals("$ cd /")) cmds.Add(new StdOut { Command = Cmd.ChangeDirectoryMoveRoot });
            else if (stdout[i].Equals("$ cd ..")) cmds.Add(new StdOut { Command = Cmd.ChangeDirectoryMoveOut });
            else if (stdout[i].StartsWith("$ cd ")) cmds.Add(new StdOut { Command = Cmd.ChangeDirectoryMoveIn, Directory = stdout[i].Split("$ cd ")[1] });
            else if (stdout[i].Equals("$ ls"))
            {
                var contents = new List<Content>();
                for (++i; i < stdout.Length; i++)
                {
                    if (stdout[i].StartsWith("$")) break;
                    if (stdout[i].StartsWith("dir ")) contents.Add(new Content { ListType = LsType.Directory, Name = stdout[i].Split("dir ")[1] });
                    else contents.Add(new Content { ListType = LsType.File, Size = int.Parse(stdout[i].Split(" ")[0]), Name = stdout[i].Split(" ")[1] });
                }
                i--;
                cmds.Add(new StdOut { Command = Cmd.List, Contents = contents });
            }
        }

        return cmds;
    }

    public Directory CreateDirectory(List<StdOut> stdout)
    {
        var directory = new Directory("/", null);

        foreach (var std in stdout.Skip(1))
        {
            if (std.Command == Cmd.ChangeDirectoryMoveIn) directory = directory.MoveIn(std.Directory);
            else if (std.Command == Cmd.ChangeDirectoryMoveOut) directory = directory.MoveOut();
            else if (std.Command == Cmd.ChangeDirectoryMoveRoot) directory = directory.MoveRoot();
            else if (std.Command == Cmd.List)
            {
                foreach (var content in std.Contents)
                {
                    if (content.ListType == LsType.Directory) directory.AddDirectory(content.Name);
                    else if (content.ListType == LsType.File) directory.AddFile(content.Name, content.Size);
                }
            }
        }

        return directory.MoveRoot();
    }

    public int GetSumOfDirectories(Directory directory, int maxDirectorySize)
    {
        int size = directory.GetSize(), sum = 0;
        if (size <= maxDirectorySize) sum += size;
        foreach (var dir in directory.Directories.Values) sum += GetSumOfDirectories(dir, maxDirectorySize);
        return sum;
    }

    public int GetClosetDirectorySize(Directory directory, int targetSize)
    {
        var matches = new List<int>();

        void traverse(Directory dir)
        {
            var size = dir.GetSize();
            if (size >= targetSize) matches.Add(size);
            foreach (var d in dir.Directories.Values) traverse(d);
        }

        traverse(directory);
        return matches.OrderBy(x => x).First();
    }
}

public class StdOut
{
    public Cmd Command { get; set; }
    public string Directory { get; set; }
    public List<Content> Contents { get; set; }
}

public enum Cmd { ChangeDirectoryMoveIn, ChangeDirectoryMoveOut, ChangeDirectoryMoveRoot, List }
public enum LsType { Directory, File }

public class Content
{
    public LsType ListType { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
}

public class Directory
{
    public Directory(string name, Directory parent) { Name = name; Parent = parent; }
    public Directory Parent { get; set; }
    public string Name { get; set; }
    public Dictionary<string, Directory> Directories { get; set; } = new Dictionary<string, Directory>();
    public Dictionary<string, FileModel> Files { get; set; } = new Dictionary<string, FileModel>();

    public void AddDirectory(string name) => Directories[name] = new Directory(name, this);

    public void AddFile(string name, int size) => Files[name] = new FileModel(name, size);

    public Directory MoveIn(string name) => Directories[name];

    public Directory MoveOut() => Parent;

    public Directory MoveRoot()
    {
        Directory root = this;
        while (root.Parent != null) root = root.Parent;
        return root;
    }

    public int GetSize() => Files.Values.Sum(x => x.Size) + Directories.Values.Select(x => x.GetSize()).Sum();
}

public class FileModel
{
    public FileModel(string name, int size) { Name = name; Size = size; }
    public string Name { get; set; }
    public int Size { get; set; }
}