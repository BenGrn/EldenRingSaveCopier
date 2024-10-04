# EldenRingSaveCopier

This application migrates characters from one Elden Ring save game to another. At time of testing this works for any version of release as long as the destination is at least the same version as the source or later.

## Installing

Executables are available on the [release page](../../releases).

## Usage

First, make a backup of your Elden Ring saves:

1. Press WINDOWS+R
2. Type `%appdata%` and press enter
3. Open the `Elden Ring` folder
4. Open the directory which is a list of numbers
5. Here you will find a file `ER0000.sl2` which is your Elden Ring savegame file
6. Copy the file `ER0000.sl2` to a backup savegame file location

Now, you can modify your save.

1. Open the `EldenRingSaveCopy` application
2. Drag the backup savegame file to the "Copy from" field
3. Drag your Elden Ring savegame file (step 5 above) to the "Copy to" field
4. Select a slot to copy from the "Copy from" field
5. Select a slot to overwrite in the "Copy to" field
6. Press "Copy"

## License

This application is available under the [MIT license](./LICENSE)
