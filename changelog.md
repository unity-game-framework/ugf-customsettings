# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased - 2019-01-01
- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/0.0.0...0.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/0?closed=1)

### Added
- Nothing.

### Changed
- Nothing.

### Deprecated
- Nothing.

### Removed
- Nothing.

### Fixed
- Nothing.

### Security
- Nothing.

## 2.0.0 - 2020-01-11
- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/1.1.0...2.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/5?closed=1)

### Changed
- `CustomSettingsEditorPackage` default folder to `ProjectSettings`.

### Removed
- Deprecated code.

## 1.1.0 - 2020-01-09
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

## 1.0.0 - 2019-09-15
- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/0.2.0-preview...1.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/3?closed=1)

### Added
- `CustomSettingsGUIScope`: `GUI` scope to drawing editor with the same setup as in `Inspector` window.

## 0.2.0-preview - 2019-09-08
- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/0.1.0-preview...0.2.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/2?closed=1)

### Added
- `CustomSettingsUtility` with `DefaultPackageFolder` constant to create `CustomSettingsPackage`.
- `CustomSettingsEditorUtility` with `DefaultPackageFolder` and `DefaultPackageExternalFolder` constants to create `CustomSettingsEditorPackage` with different folders.

### Removed
- `CustomSettingsEditorPackage` constructor to create external package settings, use constructor with specified folder path.

### Fixed
- `CustomSettingsEditorPackage` use incorrect path for external package settings.

## 0.1.0-preview - 2019-09-08
- [Commits](https://github.com/unity-game-framework/ugf-customsettings/compare/92e2613...0.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-customsettings/milestone/1?closed=1)

### Added
- This is a initial release.

---
> Unity Game Framework | Copyright 2019
