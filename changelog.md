# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.4.1](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.4.1) - 2021-02-09  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/12?closed=1)  
    

### Changed

- Update project registry ([#52](https://github.com/unity-game-framework/ugf-customsettings/pull/52))  
    - Update package publish registry.

### Fixed

- Add dependency for JsonUtility module ([#50](https://github.com/unity-game-framework/ugf-customsettings/pull/50))  
    - Add missing dependency for _JSONSerialize_ built-in module.

## [3.4.1](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.4.1) - 2021-02-09  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/12?closed=1)  
    

### Changed

- Update project registry ([#52](https://github.com/unity-game-framework/ugf-customsettings/pull/52))  
    - Update package publish registry.

### Fixed

- Add dependency for JsonUtility module ([#50](https://github.com/unity-game-framework/ugf-customsettings/pull/50))  
    - Add missing dependency for _JSONSerialize_ built-in module.

## [3.4.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.4.0) - 2020-11-30  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/11?closed=1)  
    

### Added

- Add option to delete data of the settings after creation ([#47](https://github.com/unity-game-framework/ugf-customsettings/pull/47))  
    - Add `Delete` context menu to settings data to delete any created asset or data.

## [3.3.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.3.0) - 2020-11-19  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/10?closed=1)  
    

### Added

- Add settings provider to ask before trigger data creation ([#44](https://github.com/unity-game-framework/ugf-customsettings/pull/44))  
    - Add `CustomSettings<T>.DataType` property which returns type of data settings use.
    - Add `CustomSettings<T>.ForceCreation` property to determine whether to always create data when accessed.
    - Add `CustomSettings<T>.IsLoaded` property to determine whether data is already loaded.
    - Change `CustomSettings<T>.SaveSettings()` method behaviour, now checks whether data is loaded or not, before saving.
    - Change `CustomSettingsProvider` to check whether data exists before display data in settings, and ask user for create permission, unless settings has enabled property to force data creation.

## [3.2.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.2.0) - 2020-11-12  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/9?closed=1)  
    

### Changed

- Add force save settings ([#41](https://github.com/unity-game-framework/ugf-customsettings/pull/41))  
    - Method `CustomSettings<T>.OnSaveSettings(T data)` has been deprecated. Use `CustomSettings<T>.OnSaveSettings(T data, bool force)` instead.
    - Add `force` optional argument for `CustomSettings<T>.SaveSettings()` method, to determines whether to force serialization of the settings data.
    - Change `CustomSettingsPrefs<T>.ForceSave` property to be deprecated, `PlayerPrefs.Save()` now always executed.
- Change data property to method ([#40](https://github.com/unity-game-framework/ugf-customsettings/pull/40))  
    - Property `CustomSettings<T>.Data` has been deprecated, use `CustomSettings<T>.GetData()` method instead.
    - Add `OnGetData()` method to override data loading behaviour.

## [3.1.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.1.0) - 2020-11-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/8?closed=1)  
    

### Changed

- Update to Unity 2020.2 ([#35](https://github.com/unity-game-framework/ugf-customsettings/pull/35))  

### Fixed

- Fix settings not saving to disk for settings from asset ([#36](https://github.com/unity-game-framework/ugf-customsettings/pull/36))  
    - Fix `CustomSettingsEditorAsset` and `CustomSettingsPackage` does not saving changes on disk when modify them via code.
    - Change `CustomSettingsResources` always allows saving, but it has no effect.

## [3.0.1](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.0.1) - 2020-09-26  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/7?closed=1)  
    

### Fixed

- Fix crash on CustomSettingsEditorAsset data saving ([#30](https://github.com/unity-game-framework/ugf-customsettings/pull/30))

## [3.0.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/3.0.0) - 2020-09-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/6?closed=1)  
    

### Added

- Add options to use custom settings in custom editor window ([#26](https://github.com/unity-game-framework/ugf-customsettings/pull/26))  
    - Add `CustomSettingsWindow` to draw settings in separate editor window.
    - Add `CustomSettingsDrawer` to draw settings in GUI layout.
- Add destroy settings data ([#24](https://github.com/unity-game-framework/ugf-customsettings/pull/24))  
    - Add `DestroySettings` method with `OnDestroySettings` to override destroy behaviour, non by default.
    - Add `Destroyed` event, which triggered after data destroy completed.
    - Change `LoadSettings` to destroy exist data object before loading new one.
    - Change `CustomSettingsProvider` to force load settings when activated.
- Dont display script field in settings GUI ([#21](https://github.com/unity-game-framework/ugf-customsettings/pull/21))  
    - Add `CustomSettingsData` as default implementation of `ScriptableObject` used for settings data.
    - Add `CustomSettingsDataEditor` as default implementation of `Editor` for `CustomSettingsData`, and which do not display `Script` field.
- Add support for UserSettings folder ([#20](https://github.com/unity-game-framework/ugf-customsettings/pull/20))  
    - Add `CustomSettingsEditorUtility.DEFAULT_PACKAGE_EXTERNAL_USER_FOLDER` constant to use with settings stored under the `UserSettings` folder, with default value `UserSettings/Packages`.

### Changed

- Change Saved and Loaded event to pass Data as argument ([#25](https://github.com/unity-game-framework/ugf-customsettings/pull/25))  
- Refactoring and cleanup ([#19](https://github.com/unity-game-framework/ugf-customsettings/pull/19))  
    - Add `com.ugf.editortools` dependency.
    - Remove `CustomSettingsInspectorScope`.
- Update to Unity 2020.1 ([#18](https://github.com/unity-game-framework/ugf-customsettings/pull/18))

## [2.0.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/2.0.0) - 2020-01-11  

- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/1.1.0...2.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/5?closed=1)

### Changed
- `CustomSettingsEditorPackage` default folder to `ProjectSettings`.

### Removed
- Deprecated code.

## [1.1.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/1.1.0) - 2020-01-09  

- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/1.0.0...1.1.0)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/4?closed=1)

### Added
- `CustomSettings.Saved` and `CustomSettings.Loaded` events.
- `CustomSettings.LoadSettings` to load settings data directly.
- `CustomSettings.ClearSettings` to clear settings data at storage.
- `CustomSettings.Exists` to determines whether settings data exists at storage.

### Changed
- Update to Unity 2019.3.

### Deprecated
- `CustomSettings.Save`: use `CustomSettings.SaveSettings` instead.
- `CustomSettings.OnSave` and `CustomSettings.OnLoad`: use `CustomSettings.OnSaveSettings` and `CustomSettings.OnLoadSettings`.
- `CustomSettingsGUIScope`: use `CustomSettingsInspectorScope` instead.
- `CustomSettingsEditorUtility.DefaultPackageFolder` and `CustomSettingsEditorUtility.DefaultPackageExternalFolder`: use renamed instead.

## [1.0.0](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/1.0.0) - 2019-09-15  

- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/0.2.0-preview...1.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/3?closed=1)

### Added
- `CustomSettingsGUIScope`: `GUI` scope to drawing editor with the same setup as in `Inspector` window.

## [0.2.0-preview](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/0.2.0-preview) - 2019-09-08  

- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/0.1.0-preview...0.2.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/2?closed=1)

### Added
- `CustomSettingsUtility` with `DefaultPackageFolder` constant to create `CustomSettingsPackage`.
- `CustomSettingsEditorUtility` with `DefaultPackageFolder` and `DefaultPackageExternalFolder` constants to create `CustomSettingsEditorPackage` with different folders.

### Removed
- `CustomSettingsEditorPackage` constructor to create external package settings, use constructor with specified folder path.

### Fixed
- `CustomSettingsEditorPackage` use incorrect path for external package settings.

## [0.1.0-preview](https://github.com/unity-game-framework/ugf-customsettings/releases/tag/0.1.0-preview) - 2019-09-07  

- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/92e2613...0.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/1?closed=1)

### Added
- This is a initial release.


