using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Mapping;
using ZoneSync.Domain.Models;
using ZoneSync.Domain.Services;
using ZoneSync.Domain.Services.Contracts;
using ZoneSync.Domain.Validation;

namespace ZoneSync.ConsoleDemo;

internal class Program
{
    static void Main(string[] args)
    {
        #region Services
        IFarmService farmService = new FarmService();
        ICropPlanService cropPlanService = new CropPlanService();
        ISensorConfigurationService sensorConfigurationService = new SensorConfigurationService();
        IAlertService alertService = new AlertService();
        ITaskService taskService = new TaskService();
        #endregion

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

        Zone zone = farmService.CreateZone(farm, owner, 1, 20.75m, ZoneStatus.Planted);
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

        CropPlan cropPlan = cropPlanService.CreateCropPlan(
            tomato,
            zone,
            owner,
            1,
            new DateOnly(2026, 4, 1),
            floweringStage);
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

        sensorConfigurationService.ConfigureSensor(zone, soilSensor, engineer, 1);
        #endregion

        #region Alert And Task
        Alert alert = alertService.CreateAlert(
            cropPlan,
            soilSensor,
            1,
            AlertType.OutOfRange,
            AlertSeverity.High,
            AlertStatus.Active);

        TaskItem task = taskService.CreateTaskFromAlert(
            alert,
            engineer,
            1,
            "Check soil moisture",
            "Inspect the irrigation level in the planted zone.",
            TaskPriority.High,
            DateOnly.FromDateTime(DateTime.Today.AddDays(1)));

        taskService.AssignTask(task, engineer);
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

        #region Validation
        Console.WriteLine();
        Console.WriteLine("Validation Results");
        Console.WriteLine("------------------");
        PrintValidation("Owner", owner, new UserValidator());
        PrintValidation("Farm", farm, new FarmValidator());
        PrintValidation("Zone", zone, new ZoneValidator());
        PrintValidation("Crop", tomato, new CropValidator());
        PrintValidation("Crop Plan", cropPlan, new CropPlanValidator());
        PrintValidation("Sensor", soilSensor, new SensorInstanceValidator());
        PrintValidation("Alert", alert, new AlertValidator());
        PrintValidation("Task", task, new TaskItemValidator());
        #endregion
    }

    static void PrintValidation<TModel>(string title, TModel model, IModelValidator<TModel> validator)
    {
        ValidationResult result = validator.Validate(model);
        Console.WriteLine($"{title}: {result}");
    }
}
