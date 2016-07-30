class ConstStorage
{
    // элементы игрового поля имеют два состояния
    public const int EMPTY_ELEMENT = 0;
    public const int FREE_ELEMENT = 1;

    // размеры игрового поля
    public const int HORIZONTAL_SIZE = 10;
    public const int VERTICAL_SIZE = 20;

    // промежутки времени через которые тетрамино сдвигается вниз
    public const float STEP_TIME = 0.5f;
}
