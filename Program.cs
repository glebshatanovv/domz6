using System;

// РОДИТЕЛЬСКИЙ КЛАСС РАСТЕНИЕ
class Plant
{
    public string Name { get; set; }
    public double Height { get; set; }
    public string Watering { get; set; }
    public string Light { get; set; }

    public Plant(string name, double height,
                 string watering, string light)
    {
        Name = name;
        Height = height;
        Watering = watering;
        Light = light;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine("Название: " + Name);
        Console.WriteLine("Высота: " + Height + " м");
        Console.WriteLine("Полив: " + Watering);
        Console.WriteLine("Освещение: " + Light);
    }

    public virtual void WaterPlant()
    {
        Console.WriteLine("Растение " + Name + " полито.");
    }

    public virtual void Prune()
    {
        Console.WriteLine("Растение " + Name + " обрезано.");
    }

    public virtual void Transplant()
    {
        Console.WriteLine("Растение " + Name + " пересажено.");
    }

    public virtual void ShowCareSchedule()
    {
        Console.WriteLine("График ухода за растением:");
        Console.WriteLine("- Полив: " + Watering);
        Console.WriteLine("- Освещение: " + Light);
    }

    public virtual double CalculateFertilizer()
    {
        return 0;
    }
}


// КЛАСС ЦВЕТОК
class Flower : Plant
{
    public string Color { get; set; }

    // Первый конструктор
    public Flower(string name, double height)
        : base(name, height, "2 раза в неделю", "Солнечный свет")
    {
        Color = "Красный";
    }

    // Второй конструктор
    public Flower(string name, double height, string color,
                  string watering, string light)
        : base(name, height, watering, light)
    {
        Color = color;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Цвет: " + Color);
    }

    public override void WaterPlant()
    {
        Console.WriteLine("Цветок " + Name + " полит.");
    }

    public override void Prune()
    {
        Console.WriteLine("У цветка " + Name + " удалены увядшие листья.");
    }

    public override void Transplant()
    {
        Console.WriteLine("Цветок " + Name + " пересажен.");
    }

    public override void ShowCareSchedule()
    {
        Console.WriteLine("График ухода за цветком:");
        Console.WriteLine("- Полив: " + Watering);
        Console.WriteLine("- Освещение: " + Light);
        Console.WriteLine("- Удаление увядших бутонов.");
    }

    public override double CalculateFertilizer()
    {
        return 30;
    }
}


// КЛАСС КУСТАРНИК
class Bush : Plant
{
    public string BushType { get; set; }

    // Первый конструктор
    public Bush(string name, double height)
        : base(name, height, "1 раз в неделю", "Полутень")
    {
        BushType = "Декоративный";
    }

    // Второй конструктор
    public Bush(string name, double height, string bushType,
                string watering, string light)
        : base(name, height, watering, light)
    {
        BushType = bushType;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Тип кустарника: " + BushType);
    }

    public override void WaterPlant()
    {
        Console.WriteLine("Кустарник " + Name + " полит.");
    }

    public override void Prune()
    {
        Console.WriteLine("Кустарник " + Name + " подстрижен.");
    }

    public override void Transplant()
    {
        Console.WriteLine("Кустарник " + Name +
                          " пересажен на новое место.");
    }

    public override void ShowCareSchedule()
    {
        Console.WriteLine("График ухода за кустарником:");
        Console.WriteLine("- Полив: " + Watering);
        Console.WriteLine("- Освещение: " + Light);
        Console.WriteLine("- Обрезка: один раз в месяц.");
    }

    public override double CalculateFertilizer()
    {
        return 50;
    }
}


// КЛАСС ДЕРЕВО
class Tree : Plant
{
    private int age;// Первый конструктор
    public Tree(string name, double height)
        : base(name, height, "1 раз в неделю", "Солнечный свет")
    {
        age = 5;
    }

    // Второй конструктор
    public Tree(string name, double height, int age,
                string watering, string light)
        : base(name, height, watering, light)
    {
        this.age = age;
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
                age = value;
        }
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Возраст: " + Age + " лет");
    }

    public override void WaterPlant()
    {
        Console.WriteLine("Дерево " + Name + " политo.");
    }

    public override void Prune()
    {
        Console.WriteLine("У дерева " + Name +
                          " обрезаны сухие ветви.");
    }

    public override void Transplant()
    {
        Console.WriteLine("Дерево " + Name +
                          " пересажено.");
    }

    public override void ShowCareSchedule()
    {
        Console.WriteLine("График ухода за деревом:");
        Console.WriteLine("- Полив: " + Watering);
        Console.WriteLine("- Освещение: " + Light);
        Console.WriteLine("- Обрезка ветвей: весной.");
    }

    public override double CalculateFertilizer()
    {
        return 150;
    }
}


// ГЛАВНАЯ ПРОГРАММА
class Program
{
    static void Main()
    {
        Console.WriteLine("ДОМАШНЕЕ ЗАДАНИЕ 7.1");
        Console.WriteLine("Тема: Виды растений в саду");
        Console.WriteLine("--------------------------------");

        // Создание объектов
        Plant[] plants =
        {
            new Flower("Роза", 0.5),
            new Bush("Сирень", 2.0),
            new Tree("Яблоня", 4.5),

            new Flower("Тюльпан", 0.3, "Желтый",
                       "3 раза в неделю", "Солнечный свет"),

            new Bush("Смородина", 1.5, "Плодовый",
                     "2 раза в неделю", "Полутень"),

            new Tree("Береза", 8.0, 12,
                     "1 раз в неделю", "Солнечный свет")
        };

        // Работа с растениями
        foreach (Plant plant in plants)
        {
            Console.WriteLine("\n==============================");

            plant.PrintInfo();

            Console.WriteLine("\nДействия по уходу:");

            // Полиморфизм
            plant.WaterPlant();
            plant.Prune();
            plant.Transplant();

            plant.ShowCareSchedule();

            Console.WriteLine("Необходимое удобрение: " +
                              plant.CalculateFertilizer() + " г");
        }

        // Демонстрация изменения свойства
        Console.WriteLine("\n==============================");
        Console.WriteLine("Изменение свойств растения:");

        Flower rose = new Flower("Роза", 0.5);

        Console.WriteLine("Старая высота: " + rose.Height);

        rose.Height = 0.8;
        rose.Name = "Красная роза";

        Console.WriteLine("Новое название: " + rose.Name);
        Console.WriteLine("Новая высота: " + rose.Height);

        Console.WriteLine("\nПрограмма завершена.");
    }
}