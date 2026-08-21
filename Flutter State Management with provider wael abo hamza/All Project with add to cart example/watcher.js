const fs = require("fs");
const path = require("path");

const sourceDir = path.join(__dirname, "lib");
const backupDir = "C:\\Users\\PC\\Desktop\\Lessons_Backup";

fs.watch(sourceDir, { recursive: true }, (eventType, filename) => {
  if (filename && filename.endsWith(".dart")) {
    const filePath = path.join(sourceDir, filename);

    if (fs.existsSync(filePath)) {
      const content = fs.readFileSync(filePath, "utf8");
      const txtFilename = filename.replace(".dart", ".txt");
      const targetPath = path.join(backupDir, txtFilename);

      fs.writeFileSync(targetPath, content, "utf8");
      console.log(`Saved backup as TXT: ${txtFilename}`);
    }
  }
});
