CREATE DATABASE FarmZoneSystem;
GO

USE FarmZoneSystem;
GO



CREATE TABLE [User] (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    user_firstname VARCHAR(100) NOT NULL,
    user_lastname VARCHAR(100) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    phone_number VARCHAR(20),
    role_type VARCHAR(20) CHECK (role_type IN ('Owner','Engineer','Farmer')),
    password_hash VARCHAR(255),
    created_at DATETIME DEFAULT GETDATE(),
    is_email_verified BIT DEFAULT 0,
    last_login DATETIME,
    soft_delete_at DATETIME
);


CREATE TABLE Farm (
    farm_id INT PRIMARY KEY IDENTITY(1,1),
    farm_name VARCHAR(150) NOT NULL,
    location VARCHAR(255),
    soil_type VARCHAR(100),
    total_area DECIMAL(10,2)
);

CREATE TABLE Zone (
    zone_id INT PRIMARY KEY IDENTITY(1,1),
    zone_area DECIMAL(10,2),
    zone_status VARCHAR(20) CHECK (zone_status IN ('Available','Planted','Inactive')),
    farm_id INT NOT NULL,
    created_by_user_id INT NOT NULL,

    FOREIGN KEY (farm_id) REFERENCES Farm(farm_id),
    FOREIGN KEY (created_by_user_id) REFERENCES [User](user_id)
);

CREATE TABLE Invitation (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100),
    invited_email VARCHAR(255),
    invited_phone VARCHAR(20),
    invitation_token VARCHAR(255) UNIQUE,
    verification_code VARCHAR(50),
    status VARCHAR(20) CHECK (status IN ('pending','accepted','rejected','expired','closed')),
    created_at DATETIME DEFAULT GETDATE(),
    expired_at DATETIME,
    accepted_at DATETIME,

    sent_by_user_id INT NOT NULL,
    received_by_user_id INT,
    farm_id INT,
    zone_id INT,

    FOREIGN KEY (sent_by_user_id) REFERENCES [User](user_id),
    FOREIGN KEY (received_by_user_id) REFERENCES [User](user_id),
    FOREIGN KEY (farm_id) REFERENCES Farm(farm_id),
    FOREIGN KEY (zone_id) REFERENCES Zone(zone_id)
);



CREATE TABLE Crop (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100) NOT NULL,
    season VARCHAR(20) CHECK (season IN ('winter','summer','autumn','spring')),
    category VARCHAR(100),
    irrigation_type VARCHAR(20) CHECK (irrigation_type IN ('Drip','Sprinkler','Surface'))
);

CREATE TABLE GrowthStage (
    stage_id INT PRIMARY KEY IDENTITY(1,1),
    crop_id INT NOT NULL,
    stage_name VARCHAR(100),
    stage_order INT,
    stage_duration INT,

    FOREIGN KEY (crop_id) REFERENCES Crop(id)
);

CREATE TABLE StageRequirement (
    req_id INT PRIMARY KEY IDENTITY(1,1),
    stage_id INT NOT NULL,
    req_name VARCHAR(100),
    minValue DECIMAL(10,2),
    maxValue DECIMAL(10,2),
    applicable_period VARCHAR(20)
        CHECK (applicable_period IN ('Always','Weekly','DayTime')),
    default_verification_hours INT,
    chosen_by_user BIT DEFAULT 0,

    FOREIGN KEY (stage_id) REFERENCES GrowthStage(stage_id)
);


CREATE TABLE MeasurementType (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100),
    unit VARCHAR(50)
);

CREATE TABLE SensorModel (
    id INT PRIMARY KEY IDENTITY(1,1),
    type VARCHAR(100),
    model_name VARCHAR(100),
    output_type VARCHAR(50)
);

CREATE TABLE SensorModel_MeasType (
    sensorModel_id INT,
    measType_id INT,

    PRIMARY KEY (sensorModel_id, measType_id),

    FOREIGN KEY (sensorModel_id) REFERENCES SensorModel(id),
    FOREIGN KEY (measType_id) REFERENCES MeasurementType(id)
);

CREATE TABLE SensorInstance (
    id INT PRIMARY KEY IDENTITY(1,1),
    sensorModel_id INT NOT NULL,
    serial_number VARCHAR(255) UNIQUE,
    status VARCHAR(20)
        CHECK (status IN ('active','faulty','disabled','not_found')),

    FOREIGN KEY (sensorModel_id) REFERENCES SensorModel(id)
);

CREATE TABLE StageReq_MeasType (
    req_id INT,
    measType_id INT,

    PRIMARY KEY (req_id, measType_id),

    FOREIGN KEY (req_id) REFERENCES StageRequirement(req_id),
    FOREIGN KEY (measType_id) REFERENCES MeasurementType(id)
);

CREATE TABLE CropPlan (
    id INT PRIMARY KEY IDENTITY(1,1),
    crop_id INT NOT NULL,
    zone_id INT NOT NULL,
    created_by_user_id INT NOT NULL,
    current_stage_id INT,

    planting_date DATE,
    actual_harvest_time DATE,
    isActive BIT DEFAULT 1,

    FOREIGN KEY (crop_id) REFERENCES Crop(id),
    FOREIGN KEY (zone_id) REFERENCES Zone(zone_id),
    FOREIGN KEY (created_by_user_id) REFERENCES [User](user_id),
    FOREIGN KEY (current_stage_id) REFERENCES GrowthStage(stage_id)
);

CREATE TABLE ZoneConfiguration (
    id INT PRIMARY KEY IDENTITY(1,1),
    zone_id INT NOT NULL,
    sensorInstance_id INT NOT NULL,
    configured_by_user_id INT NOT NULL,
    configured_at DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (zone_id) REFERENCES Zone(zone_id),
    FOREIGN KEY (sensorInstance_id) REFERENCES SensorInstance(id),
    FOREIGN KEY (configured_by_user_id) REFERENCES [User](user_id)
);

CREATE TABLE CheckRequirement (
    check_id INT PRIMARY KEY IDENTITY(1,1),
    plan_id INT NOT NULL,
    zone_id INT NOT NULL,
    requirement_id INT NOT NULL,
    sensorInstance_id INT,

    checkedValue DECIMAL(10,2),
    last_checked_date DATETIME,
    isSatisfied BIT,

    FOREIGN KEY (plan_id) REFERENCES CropPlan(id),
    FOREIGN KEY (zone_id) REFERENCES Zone(zone_id),
    FOREIGN KEY (requirement_id) REFERENCES StageRequirement(req_id),
    FOREIGN KEY (sensorInstance_id) REFERENCES SensorInstance(id)
);

CREATE TABLE SensorReading (
    id INT PRIMARY KEY IDENTITY(1,1),
    sensorInstance_id INT NOT NULL,
    measType_id INT NOT NULL,

    value DECIMAL(10,2),
    [date] DATE,
    [time] TIME,

    FOREIGN KEY (sensorInstance_id) REFERENCES SensorInstance(id),
    FOREIGN KEY (measType_id) REFERENCES MeasurementType(id)
);


CREATE TABLE Alert (
    id INT PRIMARY KEY IDENTITY(1,1),

    zone_id INT NOT NULL,
    cropPlan_id INT NOT NULL,
    checkReq_id INT,
    sensorInstance_id INT,
    confirmed_by_user_id INT,

    type VARCHAR(30)
        CHECK (type IN ('out_of_range','hardware_missing','faulty_sensor')),

    firing_date DATETIME,
    severity VARCHAR(20)
        CHECK (severity IN ('low','medium','high','critical')),

    status VARCHAR(20)
        CHECK (status IN ('under_review','confirmed','active','resolved','skipped')),

    FOREIGN KEY (zone_id) REFERENCES Zone(zone_id),
    FOREIGN KEY (cropPlan_id) REFERENCES CropPlan(id),
    FOREIGN KEY (checkReq_id) REFERENCES CheckRequirement(check_id),
    FOREIGN KEY (sensorInstance_id) REFERENCES SensorInstance(id),
    FOREIGN KEY (confirmed_by_user_id) REFERENCES [User](user_id)
);

CREATE TABLE Task (
    id INT PRIMARY KEY IDENTITY(1,1),

    zone_id INT NOT NULL,
    cropPlan_id INT NOT NULL,
    alert_id INT,
    created_by_user_id INT NOT NULL,

    name VARCHAR(150),
    description TEXT,

    created_at DATETIME DEFAULT GETDATE(),

    status VARCHAR(20)
        CHECK (status IN ('pending','in_progress','completed','failed','skipped')),

    due_date DATE,
    completion_time DATETIME,

    priority VARCHAR(20)
        CHECK (priority IN ('low','medium','high','urgent')),

    actual_verification_hours INT,

    type VARCHAR(20)
        CHECK (type IN ('based_on_alert','manual')),

    FOREIGN KEY (zone_id) REFERENCES Zone(zone_id),
    FOREIGN KEY (cropPlan_id) REFERENCES CropPlan(id),
    FOREIGN KEY (alert_id) REFERENCES Alert(id),
    FOREIGN KEY (created_by_user_id) REFERENCES [User](user_id)
);

CREATE TABLE Task_User (
    task_id INT,
    user_id INT,
    assigned_at DATETIME DEFAULT GETDATE(),

    PRIMARY KEY (task_id, user_id),

    FOREIGN KEY (task_id) REFERENCES Task(id),
    FOREIGN KEY (user_id) REFERENCES [User](user_id)
);

CREATE TABLE Action_Log (
    id INT PRIMARY KEY IDENTITY(1,1),

    task_id INT NOT NULL,
    executed_by_user_id INT NOT NULL,

    quantity DECIMAL(10,2),
    executed_at DATETIME DEFAULT GETDATE(),

    result TEXT,
    notes TEXT,

    FOREIGN KEY (task_id) REFERENCES Task(id),
    FOREIGN KEY (executed_by_user_id) REFERENCES [User](user_id)
);