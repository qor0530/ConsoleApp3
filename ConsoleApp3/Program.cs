using System;

namespace ConsoleApp3
{
    public class GameObject 
    {
        public string name;
        public string color;
        public int hp;
        public int damage;
        public bool isWeapon;
        public bool isShield;
        public void Get_Weapon()
        {
            isWeapon = true;
        }
        public void Jump()
        {
            Console.WriteLine("{0} 점프 !", name);
        }
        public void Dead()
        {
            Console.WriteLine("{0} 이 죽었습니다.", name);
        }
        public void Attack(GameObject obj)
        {
            if (isWeapon)
            {
                obj.hp -= this.damage;
                Console.WriteLine("{0}의 공격 !", this.name);
                if (obj.hp <= 0)
                {
                    Console.WriteLine("{0} (이)가 죽었습니다 !", obj.name);
                }
                else
                {
                    Console.WriteLine("{0} 의 남은체력 {1} !", obj.name, obj.hp);
                }
            }
            else
            {
                Console.WriteLine("{0} (이)가 무기가 없습니다 !", name);
            }
        }
        public void Eat(params int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.hp += array[i];
            }
        }
    }

    public class Player : GameObject
    {
        public Player()
        {
            name = "링크";
            color = "갈색";
            hp = 8;
            damage = 2;
            isWeapon = false;
            isShield = false;
        }
    }

    public class Monster_Warrior : GameObject
    {
        public Monster_Warrior()
        {
            name = "보코블린 전사";
            color = "파란색";
            hp = 8;
            damage = 3;
            isWeapon = true;
            isShield = false;
        }
    }

    public class Monster_Archer : GameObject 
    {
        public Monster_Archer()
        {
            name = "보코블린 궁수";
            color = "빨간색";
            hp = 6;
            damage = 2;
            isWeapon = true;
            isShield = false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player link = new Player();
            Monster_Archer Arc_Bokoblin = new Monster_Archer();
            Monster_Warrior War_Bokoblin = new Monster_Warrior();

            link.Attack(Arc_Bokoblin);
            link.Attack(War_Bokoblin);

            link.Jump();

            link.Get_Weapon();
            link.Attack(Arc_Bokoblin);
            link.Attack(War_Bokoblin);

            Arc_Bokoblin.Attack(link);
            War_Bokoblin.Attack(link);

            link.Eat(2, 3, 6);

            Arc_Bokoblin.Attack(link);
        }
    }
}