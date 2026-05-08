using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Mapping;
using ZoneSync.Domain.Models;

namespace ZoneSync.ConsoleDemo;

internal class Program
{
    static void Main(string[] args)
    {
        #region Users
        User owner = new User
        {
            UserId = 1,
            UserFirstName = "Merna",
            UserLastName = "Mohamed",
            Email = "owner@zonesync.com",
            PhoneNumber = "01000000000",
            RoleType = UserRole.Owner,
            IsEmailVerified = true
        };

        User engineer = new User
        {
            UserId = 2,
            UserFirstName = "Islam",
            UserLastName = "Helmy",
            Email = "engineer@zonesync.com",
            RoleType = UserRole.Engineer,
            IsEmailVerified = true
        };
        #endregion

        #region Farm And Zone
        Farm farm = new Farm
        {
            FarmId = 1,
            FarmName = "Green Valley Farm",
            Location = "Giza",
            SoilType = "Clay",
            TotalArea = 120.50m
        };

        Zone zone = new Zone
        {
            ZoneId = 1,
            ZoneArea = 20.75m,
            ZoneStatus = ZoneStatus.Planted,
            FarmId = farm.FarmId,
            Farm = farm,
            CreatedByUserId = owner.UserId,
            CreatedByUser = owner
        };

        farm.Zones.Add(zone);
        owner.CreatedZones.Add(zone);
        #endregion

        #region Crop Plan
        Crop tomato = new Crop
        {
            Id = 1,
            Name = "Tomato",
            Season = Season.Summer,
            Category = "Vegetables",
            IrrigationType = IrrigationType.Drip
        };

        GrowthStage floweringStage = new GrowthStage
        {
            StageId = 1,
            CropId = tomato.Id,
            Crop = tomato,
            StageName = "Flowering",
            StageOrder = 2,
            StageDuration = 18
        };

        tomato.GrowthStages.Add(floweringStage);

        CropPlan cropPlan = new CropPlan
        {
            Id = 1,
            CropId = tomato.Id,
            Crop = tomato,
            ZoneId = zone.ZoneId,
            Zone = zone,
            CreatedByUserId = owner.UserId,
            CreatedByUser = owner,
            CurrentStageId = floweringStage.StageId,
            CurrentStage = floweringStage,
            PlantingDate = new DateOnly(2026, 4, 1),
            IsActive = true
        };

        zone.CropPlans.Add(cropPlan);
        tomato.CropPlans.Add(cropPlan);
        owner.CreatedCropPlans.Add(cropPlan);
        floweringStage.CurrentCropPlans.Add(cropPlan);
        #endregion

        #region Sensors
        SensorModel soilSensorModel = new SensorModel
        {
            Id = 1,
            Type = "Soil",
            ModelName = "SM-100",
            OutputType = "Digital"
        };

        SensorInstance soilSensor = new SensorInstance
        {
            Id = 1,
            SensorModelId = soilSensorModel.Id,
            SensorModel = soilSensorModel,
            SerialNumber = "SN-SOIL-001",
            Status = SensorStatus.Active
        };

        ZoneConfiguration zoneConfiguration = new ZoneConfiguration
        {
            Id = 1,
            ZoneId = zone.ZoneId,
            Zone = zone,
            SensorInstanceId = soilSensor.Id,
            SensorInstance = soilSensor,
            ConfiguredByUserId = engineer.UserId,
            ConfiguredByUser = engineer
        };

        zone.ZoneConfigurations.Add(zoneConfiguration);
        soilSensor.ZoneConfigurations.Add(zoneConfiguration);
        engineer.ZoneConfigurations.Add(zoneConfiguration);
        #endregion

        #region Alert And Task
        Alert alert = new Alert
        {
            Id = 1,
            ZoneId = zone.ZoneId,
            Zone = zone,
            CropPlanId = cropPlan.Id,
            CropPlan = cropPlan,
            SensorInstanceId = soilSensor.Id,
            SensorInstance = soilSensor,
            Type = AlertType.OutOfRange,
            Severity = AlertSeverity.High,
            Status = AlertStatus.Active,
            FiringDate = DateTime.Now
        };

        TaskItem task = new TaskItem
        {
            Id = 1,
            ZoneId = zone.ZoneId,
            Zone = zone,
            CropPlanId = cropPlan.Id,
            CropPlan = cropPlan,
            AlertId = alert.Id,
            Alert = alert,
            CreatedByUserId = engineer.UserId,
            CreatedByUser = engineer,
            Name = "Check soil moisture",
            Description = "Inspect the irrigation level in the planted zone.",
            Status = TaskItemStatus.Pending,
            Priority = TaskPriority.High,
            Type = TaskType.BasedOnAlert,
            DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
        };

        TaskUser taskUser = new TaskUser
        {
            TaskId = task.Id,
            Task = task,
            UserId = engineer.UserId,
            User = engineer
        };

        zone.Alerts.Add(alert);
        cropPlan.Alerts.Add(alert);
        soilSensor.Alerts.Add(alert);
        alert.Tasks.Add(task);
        zone.Tasks.Add(task);
        cropPlan.Tasks.Add(task);
        engineer.CreatedTasks.Add(task);
        task.AssignedUsers.Add(taskUser);
        engineer.AssignedTasks.Add(taskUser);
        #endregion

        #region View Models
        Console.WriteLine("ZoneSync Console Demo");
        Console.WriteLine("---------------------");
        Console.WriteLine(owner.ToViewModel());
        Console.WriteLine(farm.ToViewModel());
        Console.WriteLine(zone.ToViewModel());
        Console.WriteLine(tomato.ToViewModel());
        Console.WriteLine(cropPlan.ToViewModel());
        Console.WriteLine(soilSensor.ToViewModel());
        Console.WriteLine(alert.ToViewModel());
        Console.WriteLine(task.ToViewModel());
        #endregion
    }
}
