using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("------------------Создание персонажа----------------------");
            Console.Write("Попытка создать волшебника невладеющего магией: ");
            try
            {
                Character fakeWizard = new Character("FakeWiz", Races.Wizard, Genders.Male, 34);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CharacterWithMagic Wizard = new CharacterWithMagic("Волшебник", Races.Wizard, Genders.Male, 18);
            Character Elf = new Character("Эльфийка", Races.Elf, Genders.Female, 23);
            Console.WriteLine("\n--------------Уникальные индентификаторы------------------");
            Console.WriteLine("Индентификатор первого созданного персонажа: " + Wizard.ID);
            Console.WriteLine("Индентификатор второго созданного персонажа: " + Elf.ID);
            Console.WriteLine("При создании самого первого персонажа было выброшено исключение, поэтому он не изменил индентификатор!");

            Console.WriteLine("\n--------------Вывод информации о персонаже-----------------");
            Console.WriteLine("Владеющий магией: " + Wizard.ToString());
            Console.WriteLine("Не владеющий магией: " + Elf.ToString());

            Console.WriteLine("\n--------------Сравнение персонажей по опыту-----------------");
            Character ch1 = new Character("Персонаж №1", Races.Khight, Genders.Male, 33);
            Character ch2 = new Character("ch2", Races.Elf, Genders.Female, 21);
            Character ch3 = new Character("ch3", Races.Elf, Genders.Male, 21);
            ch1.Experience = 40;
            ch2.Experience = 23;
            ch3.Experience = 30;
            Character[] exp = new Character[]
            {
                ch1, ch2, ch3
            };
            Console.Write("Вывод до сортировки: ");
            foreach (Character ch in exp)
            {
                Console.Write(ch.Experience.ToString() + " ");
            }
            Array.Sort(exp);
            Console.Write("\nВывод после сортировки: ");
            foreach (Character ch in exp)
            {
                Console.Write(ch.Experience.ToString() + " ");
            }

            Console.WriteLine("\n\n--------------Состояния персонажей-----------------");
            Console.WriteLine("Количество здоровья: " + ch1.HealthPoints.ToString() + ". Состояние: " + ch1.Condition.ToString());
            ch1.HealthPoints = 8;
            Console.WriteLine("Количество здоровья: " + ch1.HealthPoints.ToString() + ". Состояние: " + ch1.Condition.ToString());
            ch1.HealthPoints = 0;
            Console.WriteLine("Количество здоровья: " + ch1.HealthPoints.ToString() + ". Состояние: " + ch1.Condition.ToString());

            Console.WriteLine("\n--------------Персонажи могут говорить-----------------");
            Wizard.Say("Привет!");
            Elf.Say("И тебе привет!");

            Console.WriteLine("\n--------------Выучивание заклинаний-----------------");
            Wizard.LearnedSpells.AddSpell(typeof(AddHealthPoints));
            Wizard.LearnedSpells.AddSpell(typeof(Antidote));
            Console.WriteLine(Wizard.Name + " выучил два заклинания...");
            Console.WriteLine("Вывод списка выученных заклинаний: " + Wizard.ShowLearnedSpells());
            Wizard.LearnedSpells.RemoveSpell(typeof(AddHealthPoints));
            Console.WriteLine(Wizard.Name + " забыл одно заклинание...");
            Console.WriteLine("Вывод списка выученных заклинаний: " + Wizard.ShowLearnedSpells());
            Console.Write("Попытка выучить уже выученное заклинание: ");
            try
            {
                Wizard.LearnedSpells.AddSpell(typeof(Antidote));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Попытка забыть уже забытое заклинание: ");
            try
            {
                Wizard.LearnedSpells.RemoveSpell(typeof(AddHealthPoints));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Попытка выучить не заклинание: ");
            try
            {
                Wizard.LearnedSpells.AddSpell(typeof(BasiliskEye));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n--------------Добавление артефактов-----------------");
            LiveWaterBottle liveBottle = new LiveWaterBottle(BottleSizes.Small);
            DeadWaterBottle deadWaterBottle = new DeadWaterBottle(BottleSizes.Big);
            Wizard.Bag.Add(liveBottle);
            Wizard.Bag.Add(deadWaterBottle);
            Console.WriteLine("Добавили два артефакта...");
            Console.WriteLine("Вывод элементов в инвентаре: " + Wizard.ShowInventory());
            Console.Write("Попытка добавить уже добавленный артефакт: ");
            try
            {
                Wizard.Bag.Add(liveBottle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Пусть в инвентаре может храниться только два разных типа артефактов...");
            Console.Write("Попытка добавить артефакт третьего типа: ");
            try
            {
                Wizard.Bag.Add(new BasiliskEye());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Но можно добавить артефакт уже имеющегося типа...");
            LiveWaterBottle liveBottle2 = new LiveWaterBottle(BottleSizes.Medium);
            Wizard.Bag.Add(liveBottle2);
            Console.WriteLine("Вывод элементов в инвентаре: " + Wizard.ShowInventory());
            Console.WriteLine("Уберём один артефакт...");
            Wizard.Bag.Remove(liveBottle2);
            Console.WriteLine("Вывод элементов в инвентаре: " + Wizard.ShowInventory());
            Console.Write("Попытка убрать уже убранный артефакт: ");
            try
            {
                Wizard.Bag.Remove(liveBottle2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            LightningStaff staff = new LightningStaff(0);
            Console.Write("Попытка добавить использованный артефакт: ");
            try
            {
                Wizard.Bag.Add(staff);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nПередача артефактов...");
            Console.WriteLine("Инвентарь персонажа " + ch1.Name + ": " + ch1.ShowInventory());
            Console.WriteLine("Инвентарь персонажа " + Wizard.Name + ": " + Wizard.ShowInventory());
            Console.WriteLine("Передадим артефакт...");
            Wizard.GiveArtifact(deadWaterBottle, ch1);
            Console.WriteLine("Инвентарь персонажа " + ch1.Name + ": " + ch1.ShowInventory());
            Console.WriteLine("Инвентарь персонажа " + Wizard.Name + ": " + Wizard.ShowInventory());
            Console.Write("Попытка передать артефакт, которого нет: ");
            try
            {
                Wizard.GiveArtifact(deadWaterBottle, ch1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Передадим артефакт обратно...");
            ch1.GiveArtifact(deadWaterBottle, Wizard);
            Console.WriteLine("Инвентарь персонажа " + ch1.Name + ": " + ch1.ShowInventory());
            Console.WriteLine("Инвентарь персонажа " + Wizard.Name + ": " + Wizard.ShowInventory());
            Console.WriteLine("Добавим первому персонажу артефакт и попытаемся передать его в заполненный инвентарь...");
            Decoction dec = new Decoction();
            ch1.Bag.Add(dec);
            Console.WriteLine("Инвентарь персонажа " + ch1.Name + ": " + ch1.ShowInventory());
            Console.WriteLine("Инвентарь персонажа " + Wizard.Name + ": " + Wizard.ShowInventory());
            Console.Write("Попытка передать артефакт в заполненный инвентарь: ");
            try
            {
                ch1.GiveArtifact(dec, Wizard);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Инвентарь персонажа " + ch1.Name + ": " + ch1.ShowInventory());
            Console.WriteLine("Инвентарь персонажа " + Wizard.Name + ": " + Wizard.ShowInventory());

            Console.WriteLine("\n--------------Использование заклинаний-----------------");
            Console.WriteLine("У класса заклинание есть поле владелец, так что нельзя создать заклинание, если владелец его не знает...");
            Console.Write("Попытка создать невыученное заклинание: ");
            try
            {
                AddHealthPoints addHealthPoints = new AddHealthPoints(Wizard, 10);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Пусть " + Wizard.Name + " выучит все заклинания...");
            Wizard.LearnedSpells.AddSpell(typeof(AddHealthPoints));
            Wizard.LearnedSpells.AddSpell(typeof(Armor));
            Wizard.LearnedSpells.AddSpell(typeof(DieOff));
            Wizard.LearnedSpells.AddSpell(typeof(Heal));
            Wizard.LearnedSpells.AddSpell(typeof(ManaIntoHealth));
            Wizard.LearnedSpells.AddSpell(typeof(Revive));

            Console.WriteLine("\nЗаклинание Добавить здоровье...");
            ch1.HealthPoints = 90;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Добавим 5 очков здоровья...");
            Wizard.UseSpell(new AddHealthPoints(Wizard, 5), ch1);          
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Добавим 10 очков здоровья...");
            Wizard.UseSpell(new AddHealthPoints(Wizard, 10), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть второму персонажу не хватало маны...");
            Wizard.ManaPoints = 5;
            ch1.HealthPoints = 90;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Добавим 10 очков здоровья...");
            Wizard.UseSpell(new AddHealthPoints(Wizard, 10), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть не хватает маны на заданное количество здоровья, но до полного количества здоровья хватает...");
            Wizard.ManaPoints = 10;
            ch1.HealthPoints = 98;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Добавим 20 очков здоровья...");
            Wizard.UseSpell(new AddHealthPoints(Wizard, 20), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);

            Console.WriteLine("\nЗаклинание Вылечить...");
            ch1.Condition = Conditions.Ill;
            Wizard.ManaPoints = 50;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Вылечиваем...");
            Wizard.UseSpell(new Heal(Wizard), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть здоровья было меньше 10...");
            ch1.Condition = Conditions.Ill;
            ch1.HealthPoints = 8;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Вылечиваем...");
            Wizard.UseSpell(new Heal(Wizard), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть не хватает маны...");
            ch1.Condition = Conditions.Ill;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка вылечить: ");
            try
            {
                Wizard.UseSpell(new Heal(Wizard), ch1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть персонаж не болен...");
            ch1.Condition = Conditions.Healthy;
            Wizard.ManaPoints = 100;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка вылечить: ");
            try
            {
                Wizard.UseSpell(new Heal(Wizard), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);


            Console.WriteLine("\nЗаклинание Противоядие...");
            ch1.Condition = Conditions.Poisoned;
            ch1.HealthPoints = 80;
            Wizard.ManaPoints = 70;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Используем противоядие...");
            Wizard.UseSpell(new Antidote(Wizard), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть здоровья было меньше 10...");
            ch1.Condition = Conditions.Poisoned;
            ch1.HealthPoints = 8;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Используем противоядие...");
            Wizard.UseSpell(new Antidote(Wizard), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть не хватает маны...");
            ch1.Condition = Conditions.Poisoned;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка использовать противоядие: ");
            try
            {
                Wizard.UseSpell(new Antidote(Wizard), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть персонаж не отравлен...");
            ch1.Condition = Conditions.Healthy;
            Wizard.ManaPoints = 100;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка использовать противоядие: ");
            try
            {
                Wizard.UseSpell(new Antidote(Wizard), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);

            Console.WriteLine("\nЗаклинание Оживить...");
            ch1.Condition = Conditions.Dead;
            Wizard.ManaPoints = 200;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Оживляем...");
            Wizard.UseSpell(new Revive(Wizard), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть не хватает маны...");
            ch1.Condition = Conditions.Dead;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка оживить: ");
            try
            {
                Wizard.UseSpell(new Revive(Wizard), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть персонаж не мёртв...");
            ch1.Condition = Conditions.Healthy;
            Wizard.ManaPoints = 200;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка оживить: ");
            try
            {
                Wizard.UseSpell(new Revive(Wizard), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);

            Console.WriteLine("\nЗаклинание Отомри...");
            ch1.Condition = Conditions.Paralyzed;
            Wizard.ManaPoints = 100;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Используем заклинание Отомри...");
            Wizard.UseSpell(new DieOff(Wizard), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть не хватает маны...");
            ch1.Condition = Conditions.Paralyzed;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка использовать заклинание Отомри: ");
            try
            {
                Wizard.UseSpell(new DieOff(Wizard), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть персонаж не парализован...");
            ch1.Condition = Conditions.Healthy;
            Wizard.ManaPoints = 100;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка использовать заклинание Отомри: ");
            try
            {
                Wizard.UseSpell(new DieOff(Wizard), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Состояние первого персонажа: " + ch1.Condition + ". Мана второго персонажа: " + Wizard.ManaPoints);

            Console.WriteLine("\nЗаклинание Броня...");
            Wizard.ManaPoints = 250;
            ch1.HealthPoints = 100;
            Console.WriteLine("Используем заклинание Броня, отнимем здоровье во время Брони и после...");
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Wizard.UseSpell(new Armor(Wizard), ch1, 5);
            Console.WriteLine("Пытаемся уменьшить здоровье...");
            ch1.HealthPoints -= 20;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Ждём и пытаемся отнять ещё раз...");
            Thread.Sleep(600);
            ch1.HealthPoints -= 20;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть не хватает маны...");
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.Write("Попытка использовать заклинание Броня: ");
            try
            {
                Wizard.UseSpell(new Armor(Wizard), ch1, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);

            Console.WriteLine("\nЗаклинание Лечение...");
            Console.Write("Попытка использовать заклинание, когда нет артефакта: ");
            try
            {
                Wizard.UseSpell(new ManaIntoHealth(Wizard, new HealthTransmitter()), ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Добавим артефакт...");
            HealthTransmitter healthTransmitter1 = new HealthTransmitter();
            Wizard.Bag.Remove(deadWaterBottle);
            Wizard.Bag.Add(healthTransmitter1);
            ch1.HealthPoints = 80;
            Wizard.ManaPoints = 250;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Используем заклинание...");
            Wizard.UseSpell(new ManaIntoHealth(Wizard, healthTransmitter1), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Пусть не хватало маны до полного здоровья...");
            HealthTransmitter healthTransmitter2 = new HealthTransmitter();
            Wizard.Bag.Add(healthTransmitter2);
            ch1.HealthPoints = 80;
            Wizard.ManaPoints = 20;
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);
            Console.WriteLine("Используем заклинание...");
            Wizard.UseSpell(new ManaIntoHealth(Wizard, healthTransmitter2), ch1);
            Console.WriteLine("Здоровье первого персонажа: " + ch1.HealthPoints + ". Мана второго персонажа: " + Wizard.ManaPoints);

            Console.WriteLine("\n--------------Использование артефактов-----------------");
            Console.Write("Попытка использовать артефакт, которого нет в инвентаре: ");
            try
            {
                Elf.UseArtifact(new LiveWaterBottle(BottleSizes.Big));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nБутылка живой воды...");
            LiveWaterBottle liveWaterBottle1 = new LiveWaterBottle(BottleSizes.Small);
            Console.WriteLine("Для примера используем маленькую бутылку и добавим её в инвентарь...");
            Elf.Bag.Add(liveWaterBottle1);
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());
            Elf.HealthPoints = 70;
            Console.WriteLine("Здоровье персонажа до использования: " + Elf.HealthPoints);
            Elf.UseArtifact(liveWaterBottle1, Elf);
            Console.WriteLine("Здоровье персонажа после использования: " + Elf.HealthPoints);
            Console.WriteLine("После использования бутылка пропала из инвентаря...");
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());
            Console.WriteLine("Пусть количество здоровья, которое нужно восстановить до максимального, меньше, чем восстанавливает бутылка...");
            LiveWaterBottle liveWaterBottle2 = new LiveWaterBottle(BottleSizes.Small);
            Elf.Bag.Add(liveWaterBottle2);
            Elf.HealthPoints = 95;
            Console.WriteLine("Здоровье персонажа до использования: " + Elf.HealthPoints);
            Elf.UseArtifact(liveWaterBottle2, Elf);
            Console.WriteLine("Здоровье персонажа после использования: " + Elf.HealthPoints);

            Console.WriteLine("\nБутылка мёртвой воды...");
            DeadWaterBottle deadWaterBottle1 = new DeadWaterBottle(BottleSizes.Small);
            Console.WriteLine("Для примера используем маленькую бутылку и добавим её в инвентарь...");
            Wizard.Bag.Remove(liveBottle);
            Wizard.Bag.Add(deadWaterBottle1);
            Console.WriteLine("Инвентарь персонажа " + Wizard.Name + ": " + Wizard.ShowInventory());
            Wizard.ManaPoints = 70;
            Console.WriteLine("Мана персонажа до использования: " + Wizard.ManaPoints);
            Wizard.UseArtifact(deadWaterBottle1, Wizard);
            Console.WriteLine("Мана персонажа после использования: " + Wizard.ManaPoints);
            Console.WriteLine("После использования бутылка пропала из инвентаря...");
            Console.WriteLine("Инвентарь персонажа " + Wizard.Name + ": " + Wizard.ShowInventory());
            Console.WriteLine("Пусть количество маны, которое нужно восстановить до максимального, меньше, чем восстанавливает бутылка...");
            DeadWaterBottle deadWaterBottle2 = new DeadWaterBottle(BottleSizes.Small);
            Wizard.Bag.Add(deadWaterBottle2);
            Wizard.ManaPoints = 245;
            Console.WriteLine("Мана персонажа до использования: " + Wizard.ManaPoints);
            Wizard.UseArtifact(deadWaterBottle2, Wizard);
            Console.WriteLine("Мана персонажа после использования: " + Wizard.ManaPoints);

            Console.WriteLine("\nПосох Молния...");
            LightningStaff lightning = new LightningStaff(10);
            Elf.Bag.Add(lightning);
            ch1.HealthPoints = 20;
            Console.WriteLine("Используем посох, чтоб он кого-то убил...");
            Console.WriteLine("Здоровье персонажа до удара: " + ch1.HealthPoints);
            Elf.UseArtifact(lightning, ch1, 5);
            Console.WriteLine("Здоровье персонажа после удара: " + ch1.HealthPoints);
            Console.WriteLine("Посох остался в инвентаре, так как у него ещё есть мощность...");
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());
            ch1.HealthPoints = 70;
            Console.WriteLine("Если запросим мощность большую, чем есть у посоха, то используется вся возможная мощность...");
            Console.WriteLine("Здоровье персонажа до удара: " + ch1.HealthPoints);
            Elf.UseArtifact(lightning, ch1, 10);
            Console.WriteLine("Здоровье персонажа после удара: " + ch1.HealthPoints);
            Console.WriteLine("Теперь посох пропал из инвентаря, так как у него больше нет мощности...");
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());

            Console.WriteLine("\nДекокт");
            Decoction decoction1 = new Decoction();
            Elf.Bag.Add(decoction1);
            ch1.Condition = Conditions.Poisoned;
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.WriteLine("Используем на нём декокт...");
            Elf.UseArtifact(decoction1, ch1);
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.WriteLine("Попытаемся использовать декокт на здоровом персонаже...");
            Decoction decoction2 = new Decoction();
            Elf.Bag.Add(decoction2);
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.Write("Попытка использовать на нём декокт: ");
            try
            {
                Elf.UseArtifact(decoction2, ch1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.WriteLine("Декокт остался в инвентаре, так как его не использовали...");
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());

            Console.WriteLine("\nГлаз василиска...");
            Elf.Bag.Remove(decoction2);
            BasiliskEye eye1 = new BasiliskEye();
            Elf.Bag.Add(eye1);
            ch1.Condition = Conditions.Healthy;
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.WriteLine("Используем на нём глаз...");
            Elf.UseArtifact(eye1, ch1);
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.WriteLine("Попытаемся использовать глаз на мёртвом персонаже...");
            BasiliskEye eye2 = new BasiliskEye();
            Elf.Bag.Add(eye2);
            ch1.Condition = Conditions.Dead;
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.Write("Попытка использовать на нём глаз: ");
            try
            {
                Elf.UseArtifact(eye2, ch1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.WriteLine("Глаз при этом остался в инвентаре...");
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());
            Elf.Bag.Remove(eye2);
            Console.WriteLine("Попытаемся использовать глаз на уже парализованном персонаже...");
            BasiliskEye eye3 = new BasiliskEye();
            Elf.Bag.Add(eye3);
            ch1.Condition = Conditions.Paralyzed;
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.Write("Попытка использовать на нём глаз: ");
            try
            {
                Elf.UseArtifact(eye3, ch1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Состояние персонажа: " + ch1.Condition);
            Console.WriteLine("Глаз при этом остался в инвентаре...");
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());

            Console.WriteLine("\nЯдовитая слюна...");
            Elf.Bag.Remove(eye3);
            PoisonousSaliva saliva = new PoisonousSaliva(5);
            Elf.Bag.Add(saliva);
            ch1.HealthPoints = 45;
            ch1.Condition = Conditions.Healthy;
            Console.WriteLine("Используем ядовитую слюну...");
            Console.WriteLine("Здоровье персонажа: " + ch1.HealthPoints + ". И состояние персонажа: " + ch1.Condition + ". До применения артефакта.");
            Elf.UseArtifact(saliva, ch1);
            Console.WriteLine("Здоровье персонажа: " + ch1.HealthPoints + ". И состояние персонажа: " + ch1.Condition + ". После применения артефакта.");
            Console.WriteLine("Ядовитая слюна при этом осталась в инвентаре...");
            Console.WriteLine("Инвентарь персонажа " + Elf.Name + ": " + Elf.ShowInventory());
            Console.WriteLine("Сделаем так, чтобы ядовитая слюна убила персонажа...");
            ch1.HealthPoints = 20;
            ch1.Condition = Conditions.Healthy;
            Console.WriteLine("Используем ядовитую слюну...");
            Console.WriteLine("Здоровье персонажа: " + ch1.HealthPoints + ". И состояние персонажа: " + ch1.Condition + ". До применения артефакта.");
            Elf.UseArtifact(saliva, ch1);
            Console.WriteLine("Здоровье персонажа: " + ch1.HealthPoints + ". И состояние персонажа: " + ch1.Condition + ". После применения артефакта.");

            Console.WriteLine("----------------------Конец---------------------------");

            /*
            Console.WriteLine("Проверка на уникальность индентификатора: ");
            Character ch1 = new Character("John", Races.Khight, Genders.Male, 32);
            Character ch2 = new Character("Ann", Races.Elf, Genders.Female, 27);
            Console.WriteLine(ch1.ID.ToString());
            Console.WriteLine(ch2.ID.ToString());
            //изменить тоже нельзя
            //ch1.ID = 45;

            Console.WriteLine("\nПросмотр имени:");
            Console.WriteLine(ch1.Name);
            Console.WriteLine(ch2.Name);
            //имя тоже нельзя изменить
            //ch1.Name = "Джонни";

            Console.WriteLine("\n" + ch2.Age + "\n");

            Console.WriteLine("\nВывод информации:");
            Console.WriteLine(ch1);
            Console.WriteLine(ch2);

            CharacterWithMagic ch3 = new CharacterWithMagic("Wowsy", Races.Wizard, Genders.Male, 18);
            Console.WriteLine(ch3);

            ch3.LearnedSpells.AddSpell(typeof(AddHealthPoints));
            AddHealthPoints addHealth_ch3 = new AddHealthPoints(ch3, 32);
            ch2.HealthPoints = 90;
            addHealth_ch3.Cast(ch2);

            Console.WriteLine(ch2.HealthPoints);
            Console.WriteLine(ch3.ManaPoints);

            ch3.LearnedSpells.AddSpell(typeof(Heal));
            Heal heal_ch3 = new Heal(ch3);
            ch2.HealthPoints = 9;
            ch2.Condition = Conditions.Ill;
            Console.WriteLine(ch2.Condition);
            heal_ch3.Cast(ch2);
            Console.WriteLine(ch2.Condition);

            ch3.LearnedSpells.AddSpell(typeof(Antidote));
            Antidote antidote_ch3 = new Antidote(ch3);
            ch2.Condition = Conditions.Poisoned;
            Console.WriteLine(ch2.Condition);
            antidote_ch3.Cast(ch2);
            Console.WriteLine(ch2.Condition);

            ch3.LearnedSpells.AddSpell(typeof(Revive));
            ch3.ManaPoints = 150;
            Revive revive_ch3 = new Revive(ch3);
            ch2.HealthPoints = 0;
            Console.WriteLine(ch2.Condition);
            revive_ch3.Cast(ch2);
            Console.WriteLine(ch2.Condition.ToString() + ", " + ch2.HealthPoints.ToString());

            ch3.LearnedSpells.AddSpell(typeof(DieOff));
            ch3.ManaPoints = 85;
            DieOff dieoff_ch3 = new DieOff(ch3);
            ch2.Condition = Conditions.Paralyzed;
            Console.WriteLine(ch2.Condition);
            dieoff_ch3.Cast(ch2);
            Console.WriteLine(ch2.Condition.ToString() + ", " + ch2.HealthPoints.ToString());

            ch3.LearnedSpells.AddSpell(typeof(Armor));
            ch2.HealthPoints = 50;
            ch3.ManaPoints = 250;
            Armor armor_ch3 = new Armor(ch3);
            Console.WriteLine(ch2.HealthPoints);
            armor_ch3.Cast(ch2, 5);
            ch2.HealthPoints -= 20;
            Console.WriteLine(ch2.HealthPoints);
            Thread.Sleep(600);
            ch2.HealthPoints -= 20;
            Console.WriteLine(ch2.HealthPoints);

            LiveWaterBottle livebottle = new LiveWaterBottle(BottleSizes.Medium);
            Console.WriteLine(ch2.HealthPoints);
            livebottle.Cast(ch2);
            Console.WriteLine(ch2.HealthPoints);

            DeadWaterBottle deadbottle = new DeadWaterBottle(BottleSizes.Medium);
            Console.WriteLine(ch3.ManaPoints);
            deadbottle.Cast(ch3);
            Console.WriteLine(ch3.ManaPoints);
            try
            {
                deadbottle.Cast(ch3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            LightningStaff staff = new LightningStaff(23);
            Console.WriteLine(ch2.HealthPoints);
            Console.WriteLine(ch2.Condition);
            staff.Cast(ch2, 10);
            Console.WriteLine(ch2.HealthPoints);
            Console.WriteLine(ch2.Condition);
            staff.Cast(ch2, 1);
            Console.WriteLine(ch2.HealthPoints);
            Console.WriteLine(ch2.Condition);
            Console.WriteLine(staff.Power);
            ch3.ManaPoints = 150;
            revive_ch3.Cast(ch2);
            Console.WriteLine(ch2.HealthPoints);
            Console.WriteLine(ch2.Condition);

            Decoction decoction = new Decoction();
            ch2.Condition = Conditions.Poisoned;
            Console.WriteLine(ch2.Condition);
            decoction.Cast(ch2);
            Console.WriteLine(ch2.Condition);

            PoisonousSaliva saliva = new PoisonousSaliva(5);
            ch2.HealthPoints = 15;
            Console.WriteLine(ch2.HealthPoints);
            saliva.Cast(ch2);
            Console.WriteLine(ch2.HealthPoints);
            Console.WriteLine(ch2.Condition);

            ch3.ManaPoints = 150;
            revive_ch3.Cast(ch2);
            Console.WriteLine(ch2.HealthPoints);
            Console.WriteLine(ch2.Condition);
            BasiliskEye eye = new BasiliskEye();
            eye.Cast(ch2);
            Console.WriteLine(ch2.Condition);

            ch3.LearnedSpells.AddSpell(typeof(ManaIntoHealth));
            HealthTransmitter healthTransmitter = new HealthTransmitter();
            ManaIntoHealth manaIntoHealth = new ManaIntoHealth(ch3, healthTransmitter);
            Console.WriteLine(ch3.ManaPoints);
            Console.WriteLine(ch2.HealthPoints);
            ch3.ManaPoints = 201;
            //ch3.ManaPoints = 49;
            manaIntoHealth.Cast(ch2);
            Console.WriteLine(ch3.ManaPoints);
            Console.WriteLine(ch2.HealthPoints);

            Character Artem = new Character("Artem", Races.Elf, Genders.Male, 17);
            BasiliskEye a1 = new BasiliskEye();
            LiveWaterBottle a2 = new LiveWaterBottle(BottleSizes.Medium);
            LiveWaterBottle a3 = new LiveWaterBottle(BottleSizes.Small);
            DeadWaterBottle a4 = new DeadWaterBottle(BottleSizes.Big);

            Artem.Bag.Add(a1);
            Artem.Bag.Add(a2);
            Artem.Bag.Add(a3);
            try
            {
                Artem.Bag.Add(a4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(Artem.ShowInventory());
            Artem.GiveArtifact(a2, ch2);
            Console.WriteLine(Artem.ShowInventory());
            Console.WriteLine(ch2.ShowInventory());
            ch2.UseArtifact(a2, ch1);
            Console.WriteLine(ch2.ShowInventory());
            Artem.Bag.Remove(a1);
            Console.WriteLine(Artem.ShowInventory());

            try
            {
                Character fakewiz = new Character("fakewiz", Races.Wizard, Genders.Male, 123);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            CharacterWithMagic notfakewiz = new CharacterWithMagic("notfakewiz", Races.Wizard, Genders.Male, 123);

            LearnedSpellsList lis = new LearnedSpellsList();
            try
            {
                lis.AddSpell(a1.GetType());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(ch3.ShowLearnedSpells());
            */

            Console.ReadKey();
        }
        
    }
}