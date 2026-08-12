using System;

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
                Console.WriteLine("4. Lumabas");
                Console.Write("Pumili ng opsyon (1-3): ");

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
                        running = false;
                        Console.WriteLine("\nSalamat sa paggamit ng Spellbook Management System. Paalam!");
                        break;
                    default:
                        Console.WriteLine("\n[ERROR] Maling opsyon! Mangyaring pumili mula 1 hanggang 3.");
                        break;
                }
            }
        }

        // Helper method para sa pagkuha ng input mula sa user
        static void AddNewSpellMenu(Spellbook spellbook)
        {
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

            // 4. Damage Range (Validadong range kung saan ang min ay dapat 5-10 at max ay mas mataas o pantay sa min)
            int minDmg = ReadValidRange("Ipasok ang Minimum Damage (5 hanggang 10): ", 5, 10);
            int maxDmg;
            while (true)
            {
                maxDmg = ReadInteger("Ipasok ang Maximum Damage: ");
                if (maxDmg >= minDmg)
                {
                    break;
                }
                Console.WriteLine($"[ERROR] Ang Maximum Damage ay dapat hindi bababa sa Minimum Damage ({minDmg}).");
            }

            // 5. Mana Cost
            int mana = ReadInteger("Ipasok ang Mana Cost: ");

            // 6. Affinity Validation (Water, Fire, Air, Land)
            string affinity = ReadValidOption("Pumili ng Affinity (Water, Fire, Air, Land): ",
                                              new string[] { "Water", "Fire", "Air", "Land" });

            // 7. Rank Validation (Apprentice, Journeyman, Master)
            string rank = ReadValidOption("Pumili ng Rank (Apprentice, Journeyman, Master): ",
                                          new string[] { "Apprentice", "Journeyman", "Master" });

            // Paglikha ng bagong Spell Object at pagdagdag sa Spellbook
            Spell newSpell = new Spell(id, name, desc, minDmg, maxDmg, mana, affinity, rank);
            spellbook.AddSpell(newSpell);
        }

        static void RemoveSpellMenu(Spellbook spellbook)
        {
            Console.WriteLine("\n--- MAGTANGGAL NG SPELL ---");
            int id = ReadInteger("Ipasok ang Spell ID ng tatanggaling spell: ");
            spellbook.RemoveSpell(id);
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

        // Validation Method para sa Damage Range (5-10)
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
                        return option; // Ibinabalik ang tamang casing ng string
                    }
                }

                Console.WriteLine($"[ERROR] Maling pagpili! Ang mga katanggap-tanggap lamang ay: {string.Join(", ", validOptions)}");
            }
        }
    }
}