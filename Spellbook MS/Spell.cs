namespace SpellbookSystem
{
    // Class na kumakatawan sa isang Spell (Encapsulation)
    public class Spell
    {
        // Private fields
        private int spellId;
        private string spellName;
        private string description;
        private int minDamage;
        private int maxDamage;
        private int manaCost;
        private string affinity;
        private string rank;

        // Constructor
        public Spell(int id, string name, string desc, int minDmg, int maxDmg, int mana, string aff, string rnk)
        {
            this.spellId = id;
            this.spellName = name;
            this.description = desc;
            this.minDamage = minDmg;
            this.maxDamage = maxDmg;
            this.manaCost = mana;
            this.affinity = aff;
            this.rank = rnk;
        }

        // Getters para sa mga attributes
        public int GetSpellId() => spellId;
        public string GetSpellName() => spellName;
        public string GetDescription() => description;
        public int GetMinDamage() => minDamage;
        public int GetMaxDamage() => maxDamage;
        public int GetManaCost() => manaCost;
        public string GetAffinity() => affinity;
        public string GetRank() => rank;

        // Method para i-display ang detalye ng spell
        public void DisplaySpell()
        {
            Console.WriteLine($"--------------------------------------------------");
            Console.WriteLine($"ID ng Spell    : {spellId}");
            Console.WriteLine($"Pangalan       : {spellName}");
            Console.WriteLine($"Paglalarawan   : {description}");
            Console.WriteLine($"Damage Range   : {minDamage} - {maxDamage}");
            Console.WriteLine($"Mana Cost      : {manaCost}");
            Console.WriteLine($"Affinity       : {affinity}");
            Console.WriteLine($"Rank           : {rank}");
            Console.WriteLine($"--------------------------------------------------");
        }
    }
}