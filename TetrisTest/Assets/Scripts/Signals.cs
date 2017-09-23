using strange.extensions.signal.impl;

public class StartSignal : Signal { }
public class InitGameFieldSignal : Signal { }
public class DeinitGameFieldSignal : Signal { }
public class GetScoreLinesRemovedSignal : Signal<int> { }
public class CreateMainMenuSignal : Signal { }
public class DestroyFieldsViewSignal : Signal { }
public class DestroyScoreViewSignal : Signal { }
public class DestroyButtonsViewSignal : Signal { }
public class CreateRecordViewSignal : Signal { }
public class LoadPlayerDataSignal : Signal { }
public class SavePlayerDataSignal : Signal { }
public class ClearPlayerDataSignal : Signal { }
public class GameFieldUpdateSignal : Signal<int[,]> { }
public class NextFieldUpdateSignal : Signal<int[,]> { }
public class ScoreViewUpdateSignal : Signal<int> { }
public class GameOverSignal : Signal { }
public class RecordWindowClosedSignal : Signal { }
