﻿public class NotificationType
{
    // COMMANDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // init game scene
    public const string INIT_GAME_FIELDS_NOTE = "InitGameSceneNote";
    // deinit game scene
    public const string DEINIT_GAME_SCENE_NOTE = "DeinitGameSceneNote";
    // get score from removed lines
    public const string GET_SCORE_LINES_REMOVED_NOTE = "getScoreLinesRemovedNote";
    // create main menu
    public const string MAIN_MENU_CRATE_NOTE = "mainMenuCreateNote";
    // destroy fields views
    public const string DESTROY_FIELDS_VIEWS = "destroyFieldsViewsNote";
    // destroy score views
    public const string DESTROY_SCORE_VIEW = "destroyScoreView";

    // EVENTS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // update field views
    public const string GAME_FIELD_VIEW_UPDATE_NOTE = "gameFieldViewUpdateNote";
    public const string NEXT_FIELD_VIEW_UPDATE_NOTE = "nextFieldViewUpdateNote";

    // update score view
    public const string SCORE_VIEW_UPDATE_NOTE = "scoreViewUpdateNote";

    // game over
    public const string GAME_OVER_NOTE = "gameOverNote";
}