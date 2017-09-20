public interface IField
{
    void Init();
    int TetraminoNumber { get; }
    bool IsTetraminoTop { get; }
    void TetraminoMoveUp();
    void TetraminoMoveDown();
    void TetraminoMoveLeft();
    void TetraminoMoveRight();
    void NewTetramino(int number = -1);
    void FixTetramino();
    bool TestTetramino();
    bool TryToRotateTetramino();
    void TryDownTetramino();
    void RemoveLines();
}