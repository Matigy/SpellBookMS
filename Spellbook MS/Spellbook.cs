namespace SpellbookSystem
{
    // Class para sa pamamahala ng Spellbook gamit ang Array (Abstraction)
    public class Spellbook
    {
        private Spell[] spells;
        private int count; // Tagasubaybay sa bilang ng naisagawang spells

        // Constructor na nagtatakda ng maximum capacity ng array
        public Spellbook(int maxCapacity)
        {
            spells = new Spell[maxCapacity];
            count = 0;
        }

        // Method para magdagdag ng spell
        public bool AddSpell(Spell newSpell)
        {
            if (count >= spells.Length)
            {
                Console.WriteLine("\n[ERROR] Puno na ang iyong Spellbook! Hindi na makapagdagdag ng bagong spell.");
                return false;
            }

            spells[count] = newSpell;
            count++;
            Console.WriteLine("\n[SUCCESS] Tagumpay na naidagdag ang spell sa Spellbook!");
            return true;
        }

        // Method para magtanggal ng Spell gamit ang Spell ID
        public bool RemoveSpell(int id)
        {
            if (count == 0)
            {
                Console.WriteLine("\n[INFO] Walang laman ang iyong Spellbook.");
                return false;
            }

            int targetIndex = -1;

            // 1. Hanapin ang index ng spell na may katugmang ID
            for (int i = 0; i < count; i++)
            {
                if (spells[i].GetSpellId() == id)
                {
                    targetIndex = i;
                    break; // Tumigil kapag nahanap na
                }
            }

            // Kapag hindi nahanap ang ID
            if (targetIndex == -1)
            {
                Console.WriteLine($"\n[ERROR] Hindi nahanap ang Spell na may ID: {id}");
                return false;
            }

            // 2. I-shift ang lahat ng sumusunod na elements pakaliwa (Array Shifting)
            for (int i = targetIndex; i < count - 1; i++)
            {
                spells[i] = spells[i + 1];
            }

            // 3. Linisin ang huling slot at bawasan ang count
            spells[count - 1] = null;
            count--;

            Console.WriteLine($"\n[SUCCESS] Tagumpay na natanggal ang Spell (ID: {id}) sa Spellbook!");
            return true;
        }

        // Method para ipakita ang lahat ng spells
        public void DisplayAllSpells()
        {
            if (count == 0)
            {
                Console.WriteLine("\n[INFO] Walang laman ang iyong Spellbook.");
                return;
            }

            Console.WriteLine($"\n================ MGA SPELL SA SPELLBOOK ({count}/{spells.Length}) ================");
            for (int i = 0; i < count; i++)
            {
                spells[i].DisplaySpell();
            }
        }

        // Helper method para suriin kung may kaparehong ID
        public bool IsIdExists(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (spells[i].GetSpellId() == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}