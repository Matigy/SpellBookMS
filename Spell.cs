namespace SpellbookSystem
{
    // Class na kumakatawan sa isang Spell (Encapsulation)
    public class Spell
    {
        // Private fields
        private int spellId;
        private string spellName;
        private string reversedName;
        private string description;
        private int Damage;
        private int manaCost;
        private string affinity;
        private string rank;

        // Constructor
        public Spell(int id, string name, string desc, int Dmg, int mana, string aff, string rnk, string reversedName)
        {
            this.spellId = id;
            this.spellName = name;
            this.description = desc;
            this.Damage = Dmg;
            this.manaCost = mana;
            this.affinity = aff;
            this.rank = rnk;
            this.reversedName = reversedName;
        }

        // Getters para sa mga attributes
        public int GetSpellId() => spellId;
        public string GetSpellName() => spellName;
        public string GetDescription() => description;
        public int GetDamage() => Damage;
        public int GetManaCost() => manaCost;
        public string GetAffinity() => affinity;
        public string GetRank() => rank;

        // Method para i-display ang detalye ng spell
        public void DisplaySpell()
        {
            Console.WriteLine($"--------------------------------------------------");
            Console.WriteLine($"ID ng Spell    : {spellId}");
            Console.WriteLine($"Pangalan       : {spellName}");
            Console.WriteLine($"Nalangap       : {reversedName}");
            Console.WriteLine($"Paglalarawan   : {description}");
            Console.WriteLine($"Damage Range   : {Damage}");
            Console.WriteLine($"Mana Cost      : {manaCost}"); 
            Console.WriteLine($"Affinity       : {affinity}"); 
            Console.WriteLine($"Rank           : {rank}");
            Console.WriteLine($"--------------------------------------------------");
        }
    }
}