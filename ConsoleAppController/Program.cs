//a simple bit of code to send tasks to the core services
using Core.Entities;
using Core.Interfaces;
using Core.Services;

const string extention = ".temp";
const string fileNameBaseDistanceAndAngle = "distance_and_angle_from_{0}_to_{1}" + extention;
const string fileNameBaseTotalForce = "total_force_experianced_by_{0}" + extention;
const string fileNameBaseTotalHeight = "total_height_experianced_by_{0}" + extention;
const string fileNameBaseForce = "force_experianced_by_{0}_excerted_by_{1}" + extention;
const string fileNameBaseHeight = "height_experianced_by_{0}_excerted_by_{1}" + extention;
string basePath = Path.GetTempPath()+"\\Tides\\";

if(!Directory.Exists(basePath))
{
    Directory.CreateDirectory(basePath);
}

ITideCalculator tideCalculator = new TideCalculator(new OrbitItemRepositoryLocal(), new Writer());

OrbitItem Sol = new() { Id = 1, Name = "Sol", OrbitingId = 0, Mass = 1.9885e30, Radius = (int)6.957e8 };
OrbitItem Earth = new() { Id = 2, Name = "Earth", OrbitingId = Sol.Id, Mass=5.972168e24, Radius = 6371000, OrbitingDistance = 149597870700, OrbitPeriod = 0 };
OrbitItem Lua = new() { Id = 3, Name = "Lua", OrbitingId = Earth.Id, Mass = 7.346e22, Radius = 1737400, OrbitingDistance = 384399000, OrbitPeriod = 27 };

OrbitItem Sebing = new() {              Id = 1, Name = "Sebing",    OrbitingId = 0,                     Mass = 2.7839e30,   Radius = 843557000 };
OrbitItem ChurningWithMass = new() {    Id = 2, Name = "Churning",  OrbitingId = Sebing.Id,             Mass = 6.111e28,    Radius = 65194000,  OrbitingDistance = (long)4.14386e11, OrbitPeriod = 0 };
OrbitItem ChurningWithoutMass = new() { Id = ChurningWithMass.Id, Name = ChurningWithMass.Name, OrbitingId = ChurningWithMass.OrbitingId, Mass = 0, Radius = ChurningWithMass.Radius, OrbitingDistance = ChurningWithMass.OrbitingDistance, OrbitPeriod = ChurningWithMass.OrbitPeriod };
OrbitItem Eefer = new() {               Id = 3, Name = "Eefer",     OrbitingId = ChurningWithMass.Id,   Mass = 9.747e22,    Radius = 1591000,   OrbitingDistance = 462257000,       OrbitPeriod = 24 };
OrbitItem Eser = new() {                Id = 4, Name = "Eser",      OrbitingId = ChurningWithMass.Id,   Mass = 1.675e24,    Radius = 4774000,   OrbitingDistance = 536407000,       OrbitPeriod = 14400 };
OrbitItem Emer = new() {                Id = 5, Name = "Emer",      OrbitingId = ChurningWithMass.Id,   Mass = 7.448e23,    Radius = 3183000,   OrbitingDistance = 605731000,       OrbitPeriod = 288 };
OrbitItem Ahlem = new() {               Id = 6, Name = "Ahlem",     OrbitingId = Emer.Id,               Mass = 1.52616e19,  Radius = 102900,    OrbitingDistance = 9278000,         OrbitPeriod = 8 };


//for Earth
tideCalculator.ProvideRangeToWorkWith([Sol, Earth, Lua]);
int resetTime = tideCalculator.TimeTillRestart();

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Earth.Name, Sol.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Earth, Sol, Sol, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Earth.Name, Lua.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Earth, Lua, Sol, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseForce, Earth.Name, Sol.Name));
//tideCalculator.Write(Earth, Lua, Sol, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseHeight, Earth.Name, Sol.Name));


tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalForce, Earth.Name));
tideCalculator.WriteTotalTidalForceAndAngleToFile(Earth, Sol, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalHeight, Earth.Name));
tideCalculator.WriteTotalTidalHeightAndAngleToFile(Earth, Sol, 0, resetTime - 1, 1);


//for Eefer and Eser
tideCalculator.ProvideRangeToWorkWith([Sebing, ChurningWithoutMass, Eefer, Eser, Emer, Ahlem]);

resetTime = tideCalculator.TimeTillRestart();

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eefer.Name, Sebing.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eefer, Sebing, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eefer.Name, ChurningWithoutMass.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eefer, ChurningWithoutMass, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eefer.Name, Eser.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eefer, Eser, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eefer.Name, Emer.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eefer, Emer, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eefer.Name, Ahlem.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eefer, Ahlem, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalForce, Eefer.Name));
tideCalculator.WriteTotalTidalForceAndAngleToFile(Eefer, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalHeight, Eefer.Name));
tideCalculator.WriteTotalTidalHeightAndAngleToFile(Eefer, ChurningWithoutMass, 0, resetTime - 1, 1);



tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eser.Name, Sebing.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eser, Sebing, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eser.Name, ChurningWithoutMass.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eser, ChurningWithoutMass, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eser.Name, Eefer.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eser, Eefer, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eser.Name, Emer.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eser, Emer, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Eser.Name, Ahlem.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Eser, Ahlem, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalForce, Eser.Name));
tideCalculator.WriteTotalTidalForceAndAngleToFile(Eser, ChurningWithoutMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalHeight, Eser.Name));
tideCalculator.WriteTotalTidalHeightAndAngleToFile(Eser, ChurningWithoutMass, 0, resetTime - 1, 1);


//for Emer
tideCalculator.ProvideRangeToWorkWith([Sebing, ChurningWithMass, Eefer, Eser, Emer, Ahlem]);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Emer.Name, Sebing.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Emer, Sebing, ChurningWithMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Emer.Name, ChurningWithMass.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Emer, ChurningWithMass, ChurningWithMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Emer.Name, Eefer.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Emer, Eefer, ChurningWithMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Emer.Name, Eser.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Emer, Eser, ChurningWithMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseDistanceAndAngle, Emer.Name, Ahlem.Name));
tideCalculator.WriteDistanceAndAngleBetweenToFile(Emer, Ahlem, ChurningWithMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalForce, Emer.Name));
tideCalculator.WriteTotalTidalForceAndAngleToFile(Emer, ChurningWithMass, 0, resetTime - 1, 1);

tideCalculator.SetWritePath(basePath + string.Format(fileNameBaseTotalHeight, Emer.Name));
tideCalculator.WriteTotalTidalHeightAndAngleToFile(Emer, ChurningWithMass, 0, resetTime - 1, 1);