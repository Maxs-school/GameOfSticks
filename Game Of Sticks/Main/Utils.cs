public static class Utils {
    public static Random random = new();

    public static string[] Names = {
        "Crazy?",
        "IntelliJ",
        "Eclipse",
        "Visual Studio",
        "Unity",
        "Unreal Engine",
        "Godot",
        "Gamemaker Studio",
        "Gamemaker Studio 2",
        "Roblox Studio",
        "Arch (BTW)",
        "JetBrains Rider",
        "Fatal Error",
        "Blue Screen of Death",
        "Wordle",
        "JavaScript",
        "Rust",
        "TypeScript",
        "GDScript",
        "Holy C",
        "C",
        "C++",
        "Carbon",
        "Cobol",
        "Minecraft",
        "NullReferenceException",
        "null",
        "Al",
        "Garlic Bread",
        "Tux",
        "xenia",
        "Jayden",
        "Timmy",
        "Bob",
        "Perry",
        "Phineas",
        "Ferb",
        "Rick Astley",
        "Oppenheimer",
        "Java",
        "C#",
        "Python",
        "Ruby",
        "Bismuth",
        "Xenon",
        "Mercury",
        "John",
        "Jim",
        "Atticus",
        "Max",
        "Davin",
        "Caleb",
        "Isaac",
        "Xavier",
        "Alex",
        "Odin",
        "Justin",
        "McTavish",
        "Howar",
        "Neko-arc",
        "Kali",
        "Hydrogen",
        "Helium",
        "Lithium",
        "Beryllium",
        "Boron",
        "Carbon",
        "Nitrogen",
        "Oxygen",
        "Fluorine",
        "Neon",
        "Sodium",
        "Magnesium",
        "Aluminum",
        "Silicon",
        "Phosphorus",
        "Sulfur",
        "Chlorine",
        "Argon",
        "Potassium",
        "Calcium",
        "Scandium",
        "Titanium",
        "Vanadium",
        "Chromium",
        "Manganese",
        "Iron",
        "Cobalt",
        "Nickel",
        "Copper",
        "Zinc",
        "Gallium",
        "Germanium",
        "Arsenic",
        "Selenium",
        "Bromine",
        "Krypton",
        "Rubidium",
        "Strontium",
        "Yttrium",
        "Zirconium",
        "Niobium",
        "Molybdenum",
        "Technetium",
        "Ruthenium",
        "Rhodium",
        "Palladium",
        "Silver",
        "Cadmium",
        "Indium",
        "Tin",
        "Antimony",
        "Tellurium",
        "Iodine",
        "Xenon",
        "Cesium",
        "Barium",
        "Lanthanum",
        "Cerium",
        "Praseodymium",
        "Neodymium",
        "Promethium",
        "Samarium",
        "Europium",
        "Gadolinium",
        "Terbium",
        "Dysprosium",
        "Holmium",
        "Erbium",
        "Thulium",
        "Ytterbium",
        "Lutetium",
        "Hafnium",
        "Tantalum",
        "Tungsten",
        "Rhenium",
        "Osmium",
        "Iridium",
        "Platinum",
        "Gold",
        "Mercury",
        "Thallium",
        "Lead",
        "Bismuth",
        "Polonium",
        "Astatine",
        "Radon",
        "Francium",
        "Radium",
        "Actinium",
        "Thorium",
        "Protactinium",
        "Uranium",
        "Neptunium",
        "Plutonium",
        "Americium",
        "Curium",
        "Berkelium",
        "Californium",
        "Einsteinium",
        "Fermium",
        "Mendelevium",
        "Nobelium",
        "Lawrencium",
        "Rutherfordium",
        "Dubnium",
        "Seaborgium",
        "Bohrium",
        "Hassium",
        "Meitnerium"
    };

    public static string GetRandomName() {
        var randomLineNumber = random.Next(0, Names.Length - 1);
        return Names[randomLineNumber];
    }

    public static void PrintSticksBar(int maxSticks, int numSticks) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"┌─{new string('─', maxSticks)}─┐");
        var spacesToPrint = maxSticks - numSticks;

        Console.Write("│ ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(new string('|', numSticks) + new string(' ', spacesToPrint));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" │");

        Console.WriteLine($"└─{new string('─', maxSticks)}─┘");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static int AskUntilInRange(int min, int max, string prompt) {
        while (true) {
            Console.Write(prompt);

            int number;
            var isParsable = int.TryParse(Console.ReadLine(), out number);

            if (isParsable && number <= max && number >= min) return number;
            Console.WriteLine("Invalid Input");
        }
    }

    public static string GetStringSafe(string prompt) {
        string? name = null;
        while (name == null) {
            Console.Write(prompt);
            name = Console.ReadLine();
            if (name == null) Console.WriteLine("Invalid input");
        }

        return name;
    }

    public enum GameType
    {
        PlayerVsPlayer,
        PlayerVsAi,
        Quit
    }

    public static GameType GetGameType() {
        Console.WriteLine("What kinda of game do you want to play?");
        Console.WriteLine("Player vs AI (1)");
        Console.WriteLine("Player vs Player (2)");
        Console.WriteLine("Quit (3)");

        int choice = AskUntilInRange(1, 3, "Choice: ");

        switch (choice) {
            case 1: return GameType.PlayerVsAi;
            case 2: return GameType.PlayerVsPlayer;
            case 3: return GameType.Quit;
            default: return GameType.Quit;
        }
    }

    public static bool GetTrueFalse(string prompt) {
        while (true) {
            Console.Write($"{prompt} (y/n) ");
            string input = Console.ReadLine()?.ToLower() ?? "null";
            switch (input) {
                case "y":
                case "yes":
                case "ye":
                case "true": {
                    return true;
                }
                case "n":
                case "no":
                case "nuh":
                case "false": {
                    return false;
                }
            }

            Console.WriteLine("Invalid input");
        }

    }
}