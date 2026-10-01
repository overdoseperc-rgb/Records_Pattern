namespace KT16;

public static class ShapeClassifier
{
    public static string Classify(object shape) => shape switch
    {
        Circle { Center: { X: 0, Y: 0 } } => "окружность в начале координат",
        Circle { Radius: 0 } => "вырожденная окружность (точка)",
        Circle c => $"окружность с радиусом {c.Radius}",
        Rectangle r when r.TopLeft == r.BottomRight => "вырожденный прямоугольник (точка)",
        Rectangle r => $"прямоугольник с размерами {Math.Abs(r.BottomRight.X - r.TopLeft.X)} × {Math.Abs(r.BottomRight.Y - r.TopLeft.Y)}",
        _ => "неизвестная фигура"
    };
}
