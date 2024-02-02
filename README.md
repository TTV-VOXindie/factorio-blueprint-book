# Vox's Blueprints
[![Convert Blueprint String to JSON](https://github.com/TTV-VOXindie/factorio-blueprint-book/actions/workflows/blueprint-string-to-json.yml/badge.svg?branch=main)](https://github.com/TTV-VOXindie/factorio-blueprint-book/actions/workflows/blueprint-string-to-json.yml)

This is a repository meant for storing blueprints made by [VOXindie](https://www.twitch.tv/voxindie).

When the [blueprint string](Blueprint%20Files/BlueprintBook.txt) is updated, a [github action](/.github/workflows/blueprint-string-to-json.yml) is run to automatically update files in the [Blueprint Files](Blueprint%20Files) folder.

The [github action](/.github/workflows/blueprint-string-to-json.yml) automatically decodes the [blueprint string](Blueprint%20Files/BlueprintBook.txt) into [JSON](Blueprint%20Files/BlueprintBook.json) and then breaks the [JSON](Blueprint%20Files/BlueprintBook.json) up into [separate files](Blueprint%20Files/JSON) for each nested blueprint book and blueprint found within.
