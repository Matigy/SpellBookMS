using System;
using System.Linq; // Kailangan ito para sa .Reverse().ToArray()

namespace SpellbookSystem
{
    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Paglikha ng Spellbook na may maximum capacity na 100 spells
            Spellbook mySpellbook = new Spellbook(100);
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== SISTEMA NG PAMAMAHALA NG SPELLBOOK ===");
                Console.WriteLine("1. Magdagdag ng Bagong Spell");
                Console.WriteLine("2. Magtanggal ng Lumang Spell");
                Console.WriteLine("3. Ipakita ang Lahat ng Spell");
                Console.WriteLine("4. Maghasa ng Spell (Train / Attack)");
                Console.WriteLine("5. Lumabas");
                Console.Write("Pumili ng opsyon (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewSpellMenu(mySpellbook);
                        break;
                    case "2":
                        RemoveSpellMenu(mySpellbook);
                        break;
                    case "3":
                        mySpellbook.DisplayAllSpells();
                        break;
                    case "4":
                        Train(mySpellbook); // Inayos: Train na lang ang tatawagin dito
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("\nSalamat sa paggamit ng Spellbook Management System. Paalam!");
                        break;
                    default:
                        Console.WriteLine("\n[ERROR] Maling opsyon! Mangyaring pumili mula 1 hanggang 5.");
                        break;
                }
            }
        }

        static void AddNewSpellMenu(Spellbook spellbook)
        {
            // Paglikha ng mga Spell Object for testing
            Spell newSpell = new Spell(1, "Tubig Hangin", "Malakas na tubig sa hangin", 5, 10, "Hangin", "Bagito", "nignaH gibuT");
            spellbook.AddSpell(newSpell);
            Spell newSpell2 = new Spell(2, "Lupang Hangin", "Malakas na tubig sa hangin", 7, 20, "Hangin", "Bagito", "nignaH gnapuL");
            spellbook.AddSpell(newSpell2);
            Spell newSpell3 = new Spell(3, "Hangin Apoy", "Malakas na tubig sa hangin", 10, 30, "Hangin", "Beterano", "yopA nignaH");
            spellbook.AddSpell(newSpell3);

            Console.WriteLine("\n--- MAGDAGDAG NG BAGONG SPELL ---");

            // 1. Spell ID
            int id = ReadInteger("Ipasok ang Spell ID: ");
            if (spellbook.IsIdExists(id))
            {
                Console.WriteLine("[ERROR] Ang Spell ID na ito ay umiiral na! Subukang muli sa ibang ID.");
                return;
            }

            // 2. Spell Name
            Console.Write("Ipasok ang Pangalan ng Spell: ");
            string name = Console.ReadLine();

            // 3. Description
            Console.Write("Ipasok ang Paglalarawan (Description): ");
            string desc = Console.ReadLine();

            // 4. Damage Range
            int Dmg = ReadValidRange("Ipasok ang Range Damage (5 hanggang 10): ", 5, 10);

            // 5. Mana Cost
            int mana = ReadInteger("Ipasok ang Mana Cost: ");

            // 6. Affinity Validation
            string affinity = ReadValidOption("Pumili ng Affinity (Tubig, Apoy, Hangin, Lupa): ",
                                              new string[] { "Tubig", "Apoy", "Hangin", "Lupa" });

            // 7. Rank Validation
            string rank = ReadValidOption("Pumili ng Rank (Bagito, Sakslang, Beterano): ",
                                          new string[] { "Bagito", "Sakslang", "Beterano" });

            // 8. Reverse Name
            string reversedName = new string(name.ToCharArray().Reverse().ToArray());

            // Paglikha ng bagong Spell Object at pagdagdag sa Spellbook
            Spell userSpell = new Spell(id, name, desc, Dmg, mana, affinity, rank, reversedName);
            spellbook.AddSpell(userSpell);
        }

        static void RemoveSpellMenu(Spellbook spellbook)
        {
            Console.WriteLine("\n--- MAGTANGGAL NG SPELL ---");
            int id = ReadInteger("Ipasok ang Spell ID ng tatanggaling spell: ");
            spellbook.RemoveSpell(id);
        }

        static void Train(Spellbook spellbook)
        {
            // Fixed values per session
            int spellPt = 50; 
            int manaPt = 500;
            
            // Statistics trackers
            int totalDamage = 0;
            int mostDamage = 0;
            int spellCount = 0;

            bool training = true;

            Console.WriteLine("\n=== SIMULA NG TRAINING SESSION ===");

            while (training && manaPt > 0)
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine($"[STATUS] Spell Points: {spellPt} | Mana Points: {manaPt}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("1. Atakihin ang Dummy (Pumili ng Spell)");
                Console.WriteLine("2. Tapusin ang Training (Lumabas)");
                Console.Write("Pumili ng opsyon (1-2): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    int id = ReadInteger("Ipasok ang Spell ID na gagamitin sa pag-atake: ");
                    Spell selectedSpell = spellbook.GetSpell(id);

                    if (selectedSpell == null)
                    {
                        Console.WriteLine("[ERROR] Ang Spell ID na ito ay hindi umiiral.");
                        continue;
                    }

                    // Tukuyin ang deduction sa Spell Points batay sa Rank
                    int spCost = 0;
                    string rank = selectedSpell.GetRank();
                    if (rank == "Bagito") spCost = 5;
                    else if (rank == "Sakslang") spCost = 10;
                    else if (rank == "Beterano") spCost = 15;

                    // I-check kung sapat ang Spell Points
                    if (spellPt < spCost)
                    {
                        Console.WriteLine($"\n[ERROR] Kulang ang iyong Spell Points! (Kailangan: {spCost}, Meron: {spellPt})");
                        continue;
                    }

                    // I-check kung sapat ang Mana Points
                    int manaCost = selectedSpell.GetManaCost();
                    if (manaPt < manaCost)
                    {
                        Console.WriteLine($"\n[ERROR] Kulang ang iyong Mana! (Kailangan: {manaCost}, Meron: {manaPt})");
                        continue;
                    }

                    // === ISAGAWA ANG PAG-ATAKE ===
                    spellPt -= spCost;
                    manaPt -= manaCost;
                    if (manaPt < 0) manaPt = 0; 

                    int damageDealt = selectedSpell.GetDamage();
                    
                    // I-update ang statistics
                    spellCount++;
                    totalDamage += damageDealt;
                    if (damageDealt > mostDamage)
                    {
                        mostDamage = damageDealt;
                    }

                    // I-display ang resulta ng turn
                    Console.WriteLine($"\n💥 [ATTACK] Ginamit mo ang '{selectedSpell.GetSpellName()}'!");
                    Console.WriteLine($"   - Nabawasan ka ng {spCost} Spell Points.");
                    Console.WriteLine($"   - Nabawasan ka ng {manaCost} Mana Points.");
                    Console.WriteLine($"   - Nagdulot ka ng {damageDealt} DAMAGE sa dummy!");
                }
                else if (choice == "2")
                {
                    training = false; 
                }
                else
                {
                    Console.WriteLine("\n[ERROR] Maling opsyon! Pumili lamang ng 1 o 2.");
                }
            }

            // === TRAINING SUMMARY ===
            Console.WriteLine("\n==================================================");
            Console.WriteLine("               TAPOS NA ANG TRAINING");
            Console.WriteLine("==================================================");
            
            if (manaPt <= 0)
            {
                Console.WriteLine("[INFO] Naubos na ang iyong Mana Points!\n");
            }

            Console.WriteLine($"Kabuuang Spells na Nagamit : {spellCount}");
            Console.WriteLine($"Kabuuang Damage na Nagawa  : {totalDamage}");
            Console.WriteLine($"Pinakamalakas na Atake     : {mostDamage}");
            Console.WriteLine("==================================================");
            Console.WriteLine("Bumabalik sa pangunahing menu...");
        }

        // Validation Method para sa Integer Inputs
        static int ReadInteger(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                {
                    return value;
                }
                Console.WriteLine("[ERROR] Maling input! Mangyaring magpasok ng positibong numero.");
            }
        }

        // Binalik ko ang ReadValidRange na nawala sa code mo
        static int ReadValidRange(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"[ERROR] Ang numero ay dapat nasa pagitan ng {min} at {max}.");
            }
        }

        // Validation Method para sa Predefined Options (Affinity & Rank)
        static string ReadValidOption(string prompt, string[] validOptions)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim();

                foreach (string option in validOptions)
                {
                    if (option.Equals(input, StringComparison.OrdinalIgnoreCase))
                    {
                        return option; 
                    }
                }

                Console.WriteLine($"[ERROR] Maling pagpili! Ang mga katanggap-tanggap lamang ay: {string.Join(", ", validOptions)}");
            }
        }
    }
}