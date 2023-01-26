# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]


## [1.1.1] - 2023-01-26

### Changed

- Fixed username json ignore condition 

## [1.1.0] - 2023-01-26

### Added 

- Added slack [composition objects](https://api.slack.com/reference/block-kit/composition-objects)
- Added json ignore condition to when writing null

### Changed

- Throws InvalidOperationException if fields are more than 10 for a single attachment
- Throws InvalidOperationException if attachment are more than 10 for a single message

## [1.0.0] - 2022-09-17

### Added

- Added models for slack message, attachment and field
- Addex slack slash request models
- Added http extensions for slack message

[Unreleased]: https://github.com/ZenExtensions/slack-models/compare/1.1.1...HEAD
[1.1.1]: https://github.com/ZenExtensions/slack-models/compare/1.1.0...1.1.1
[1.1.0]: https://github.com/ZenExtensions/slack-models/compare/1.0.0...1.1.0
[1.0.0]: https://github.com/ZenExtensions/slack-models/releases/tag/1.0.0