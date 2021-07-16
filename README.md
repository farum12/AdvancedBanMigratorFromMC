# AdvancedBanMigratorFromMC
Very simple, yet useful tool intended for migrating from Minecraft bans to Advanced Ban's MySQL database. It's C# code which generates INSERT statement, which is based on your server's banned-players and banned-ips jsons.
Please note, that all migrated bans will be set as **PERMANENT**.

## Usage
1. Open AdvancedBanMigratorFromMC.sln with Visual Studio or any other IDE.
2. Go to Program.cs.
3. Replace value of pathToBannedPlayers and pathToBannedIps variables with paths to corresponding files.
4. [Optional] Replace value of punishementsTableName and punishmentHistoryTableName variables. The ones here are named after default AdvancedBan settings.
5. [Optional, change if your server is in online mode] Replace value of populateUUIDwithName variable ONLY if your server is in online mode. By default it's set as true for offline mode servers.
6. Run the program.
7. The output is split into two INSERTs - one for Punishments table (currently banned players) and PunishmentHistory (for ban history).
8. Copy first INSERT  (from INSERT till the end of it, marked with ";"). 
9. Paste into SQL query and execute.
10. Copy second INSERT (from INSERT till the end of it, marked with ";"). 
11. Paste into SQL query and execute.
12. Voila.
