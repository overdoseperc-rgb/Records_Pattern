using System.Globalization;
using System.Text;
using KT16;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("КТ №16. Вариант 1 — Геометрические фигуры через записи");

try
{
    while (true)
    {
        Console.WriteLine("\n1 — Окружность\n2 — Прямоугольник\n0 — Выход");
        Console.Write("Выберите действие: ");
        string? choice = Console.ReadLine();
        if (choice is null or "0")
            break;

        object shape;
        switch (choice.Trim())
        {
            case "1":
                Point center = ReadPoint("Центр окружности");
                double radius = ReadNumber("Радиус (не меньше 0): ", nonNegative: true);
                shape = new Circle(center, radius);
                break;
            case "2":
                Point topLeft = ReadPoint("Первая точка (TopLeft)");
                Point bottomRight = ReadPoint("Вторая точка (BottomRight)");
                shape = new Rectangle(topLeft, bottomRight);
                break;
            default:
                Console.WriteLine("Ошибка: выберите 1, 2 или 0.");
                continue;
        }

        Console.WriteLine($"\nВведённые данные: {shape}");
        Console.WriteLine($"Классификация: {ShapeClassifier.Classify(shape)}");
    }
}
catch (EndOfStreamException)
{
    Console.WriteLine("\nВвод завершён.");
}

Console.WriteLine("Программа завершена.");

static Point ReadPoint(string label)
{
    Console.WriteLine(label);
    return new Point(ReadNumber("X: "), ReadNumber("Y: "));
}

static double ReadNumber(string prompt, bool nonNegative = false)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine() ?? throw new EndOfStreamException();
        // Разрешаем точку и запятую как десятичный разделитель, без разделителей тысяч.
        if (double.TryParse(input.Trim().Replace(',', '.'), NumberStyles.Float,
                CultureInfo.InvariantCulture, out double value)
            && double.IsFinite(value) && (!nonNegative || value >= 0))
            return value;

        Console.WriteLine(nonNegative
            ? "Ошибка: введите конечное число не меньше 0."
            : "Ошибка: введите конечное число (например, 2,5 или 2.5).");
    }
}
