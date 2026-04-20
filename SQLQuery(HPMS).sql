Use dbHPMS

Go
Create table tbStaff(
  StaffID smallint primary key,
  StaffNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN,
  StaffNameEN varchar(25),
  StaffGender varchar(6) CHECK (StaffGender IN ('Male', 'Female')),
  BirthDate date,
  StaffPhone varchar(20),
  StaffAddress varchar(255),
  StaffPosition varchar(150),
  Salary money,
  HiredDate date,
  IsStopWork bit,
  StaffPhoto varbinary(MAX)
)

Go
Create Table tbDoctor (
  DoctorID int Primary key, DoctorName varchar(35),
  DoctorGender varchar(6) CHECK (DoctorGender IN ('Male', 'Female')),
  DoctorAddress varchar(255),
  DoctorBirthDate date, DoctorPhone varchar(20),
  DoctorHiredDate date, DoctorPhoto varbinary(MAX),
  DoctorSalary money, StoppedWork bit
)

Go
Create Table tbPatient (
  PatientID int Primary key,
  PatientNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN, 
  PatientNameEN varchar(25),
  PatientGender varchar(6) CHECK (PatientGender IN ('Male', 'Female')),
  PatientAddress varchar(255),
  PatientBirthDate date, PatientPhone varchar(20),
  PatientPhoto varbinary(MAX)
)

Go
create table tbMedicineStock(
  MedicineStockID int primary key,
  MedicineStockName varchar(200),
  Category varchar(150),
  UnitPrice money,
  StockQty smallint
)

Go
create table tbSupplier(
  SupplierID tinyint primary key,
  SupplierName varchar(200),
  SupplierPhone varchar(25),
  SupplierAddress varchar(255)
)

Go
Create Table tbDisease(
  DiseaseID int Primary key, 
  DiseaseName varchar(35),
  DiseaseCategory varchar(100)
)

Go
Create table tbAppointment(
  AppointmentID int primary key,
  AppointmentDate date,
  AppointmentStatus varchar(35),
  PatientID int,
  PatientNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN, 
  PatientNameEN varchar(25),
  DoctorID int,
  DoctorName nvarchar(35),
  foreign key (PatientID) references tbPatient(PatientID)
  on delete cascade on update cascade,
  foreign key (DoctorID) references tbDoctor(DoctorID)
  on delete cascade on update cascade,
  Duration time
)

Go
create table tbImport(
  ImportID bigint primary key,
  ImportDate date,
  SupplierID tinyint,
  StaffID smallint,
  SupplierName varchar(200),
  StaffNameEN varchar(25),
  StaffNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN,
  StaffPosition varchar(150),
  foreign key (StaffID) references tbStaff(StaffID)
  on delete cascade on update cascade,
  foreign key (SupplierID) references tbSupplier (SupplierID)
  on delete cascade on update cascade,
  TotalAmount money
)



Go
Create Table tbTreatment (
  TreatmentID int Primary key, TreatmentName varchar(25),
  TreatmentDate date, 
  PatientID int, PatientNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN, 
  PatientNameEN varchar(25),
  DoctorID int, DoctorName varchar(35),
  Foreign key (PatientID) References tbPatient (PatientID)
    On Delete Cascade On Update Cascade,
  Foreign key (DoctorID) References tbDoctor (DoctorID)
    On Delete Cascade On Update Cascade
)

Go
Create Table tbPayment (
    PaymentID INT PRIMARY KEY,
    PayDate DATE,
    PaidAmount MONEY,
    PaymentMethod VARCHAR(50),
    PatientID INT,
    StaffID smallint,
	StaffNameEN varchar(25),
	StaffNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN,
	StaffPosition varchar(150),
    FOREIGN KEY (PatientID) REFERENCES tbPatient(PatientID)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (StaffID) REFERENCES tbStaff(StaffID)
        ON DELETE CASCADE ON UPDATE CASCADE
)

Go
Create Table tbPrescription(
    PrescriptionID Int PRIMARY KEY,
    Diagnosis VARCHAR(100),
    DateIssued DATE,
    PatientID Int,
    PatientNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN,
    PatientNameEN varchar(25),
    DoctorID Int,
    DoctorName varchar(35),
    Foreign key (PatientID) References tbPatient (PatientID)
     On Delete Cascade On Update Cascade,
    Foreign key (DoctorID) References tbDoctor (DoctorID)
     On Delete Cascade On Update Cascade
)

Go
CREATE TABLE tbOrder (
    OrderID INT PRIMARY KEY,
    OrderDate DATE, 
    StaffID smallint,
    StaffNameEN varchar(25),
	StaffNameKH nvarchar(35) collate SQL_Latin1_General_CP850_BIN,
	StaffPosition varchar(150),
    SupplierID tinyint,
	SupplierName varchar(200),
    TotalAmount DECIMAL(10,2),
    Foreign key (StaffID) References tbStaff (StaffID)
    On Delete Cascade On Update Cascade,
    Foreign key (SupplierID) References tbSupplier (SupplierID)
    On Delete Cascade On Update Cascade
)


Go
create table tbImportDetail(
  ImportID bigint,
  MedicineStockID int,
  MedicineStockName varchar(200),
  ImportQty smallint,
  ImportUnitPrice money,
  ImportAmount money,
  foreign key (ImportID) references tbImport(ImportID)
  on delete cascade on update cascade,
  foreign key (MedicineStockID) references tbMedicineStock(MedicineStockID)
  on delete cascade on update cascade,
  primary key(ImportID, MedicineStockID)
)

Go
Create Table tbTreatmentDetail(
  TreatmentID int, DiseaseID int, DiseaseName nvarchar(35),
  TreatmentMethod varchar(100), Duration time,
  Foreign key (TreatmentID) References tbTreatment (TreatmentID)
    On Delete Cascade On Update Cascade,
  Foreign key (DiseaseID) References tbDisease (DiseaseID)
    On Delete Cascade On Update Cascade,
  Primary key (TreatmentID, DiseaseID)
)

Go
Create Table tbOrderDetail (
      OrderID INT,
      MedicineStockID INT,
      MedicineStockName varchar(200),
      Quantity INT,
      UnitPrice DECIMAL(10, 2),
      SubTotal DECIMAL(10, 2),
	  Foreign key (OrderID) References tbOrder (OrderID)
		On Delete Cascade On Update Cascade,
	  Foreign key (MedicineStockID) References tbMedicineStock (MedicineStockID)
		On Delete Cascade On Update Cascade,
	  PRIMARY KEY (OrderID, MedicineStockID),
)

Go
Create Table tbPrescriptionDetail(
  PrescriptionID INT NOT NULL,
  DiseaseID INT NOT NULL,
  DiseaseName NVarchar(35),
  TreatmentMethod VARCHAR(100),
  Duration time,
  Foreign key (PrescriptionID) References tbPrescription (PrescriptionID)
    On Delete Cascade On Update Cascade,
  Foreign key (DiseaseID) References tbDisease (DiseaseID)
    On Delete Cascade On Update Cascade,
  Primary key (PrescriptionID, DiseaseID)
)

Go
CREATE VIEW vPatientList AS
SELECT PatientID, 
       PatientNameEN,
       PatientNameKH,
       CAST(PatientID AS VARCHAR) collate SQL_Latin1_General_CP850_BIN + ' - ' + PatientNameKH + ' - ' + PatientNameEN AS DisplayText
FROM tbPatient;

Go
CREATE VIEW vDoctorList AS
SELECT 
    DoctorID, 
    DoctorName,
    CAST(DoctorID AS VARCHAR) + ' - ' + DoctorName AS DisplayText
FROM tbDoctor;

Go
CREATE VIEW vDiseaseList AS
SELECT 
    DiseaseID,
    DiseaseName,
    CAST(DiseaseID AS VARCHAR) + ' - ' + DiseaseName AS DisplayText
FROM tbDisease;

Go
CREATE VIEW vStaffList AS
SELECT 
    StaffID, 
	StaffNameEN,
    StaffNameKH,
	StaffPosition,
    CAST(StaffID AS VARCHAR) collate SQL_Latin1_General_CP850_BIN  + ' - ' + StaffNameKH + ' - ' + StaffNameEN + ' - ' + StaffPosition AS DisplayText
FROM tbStaff;

Go
CREATE VIEW vSupplierList AS
SELECT 
    SupplierID,
    SupplierName,
    CAST(SupplierID AS VARCHAR) collate SQL_Latin1_General_CP850_BIN + ' - ' + SupplierName AS DisplayText
FROM tbSupplier;

Go
CREATE VIEW vMedicineStockList AS
SELECT 
    MedicineStockID,
    MedicineStockName,
    CAST(MedicineStockID AS VARCHAR) + ' - ' + MedicineStockName AS DisplayText
FROM tbMedicineStock;

Go
CREATE PROCEDURE sp_InsertStaff
    @StaffID        SMALLINT,
    @StaffNameKH    NVARCHAR(35), @StaffNameEN VARCHAR(25),
    @StaffGender    VARCHAR(6), @BirthDate DATE,
    @StaffPhone     VARCHAR(20), @StaffAddress VARCHAR(255),
    @StaffPosition  VARCHAR(150), @Salary MONEY,
    @HiredDate      DATE,  @IsStopWork BIT
    --@StaffPhoto     VARBINARY(MAX)
AS
BEGIN
    INSERT INTO tbStaff (
        StaffID, StaffNameKH, StaffNameEN, StaffGender, BirthDate,
        StaffPhone, StaffAddress, StaffPosition, Salary,
        HiredDate, IsStopWork
		--StaffPhoto
    )
    VALUES (
        @StaffID, @StaffNameKH, @StaffNameEN, @StaffGender, @BirthDate,
        @StaffPhone, @StaffAddress, @StaffPosition, @Salary,
        @HiredDate, @IsStopWork
		--@StaffPhoto
    )
END


Go
CREATE PROCEDURE sp_UpdateStaff
    @StaffID        SMALLINT,
    @StaffNameKH    NVARCHAR(35), @StaffNameEN VARCHAR(25),
    @StaffGender    VARCHAR(6), @BirthDate DATE,
    @StaffPhone     VARCHAR(20), @StaffAddress VARCHAR(255),
    @StaffPosition  VARCHAR(150), @Salary MONEY,
    @HiredDate      DATE,  @IsStopWork BIT
    --@StaffPhoto     VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tbStaff
    SET 
        StaffNameKH = @StaffNameKH,
        StaffNameEN = @StaffNameEN,
        StaffGender = @StaffGender,
        BirthDate = @BirthDate,
        StaffPhone = @StaffPhone,
        StaffAddress = @StaffAddress,
        StaffPosition = @StaffPosition,
        Salary = @Salary,
        HiredDate = @HiredDate,
        IsStopWork = @IsStopWork
        --StaffPhoto = @StaffPhoto
    WHERE StaffID = @StaffID;
END

Go
CREATE PROCEDURE sp_SearchStaffByNameEN
    @StaffNameEN varchar(25) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        StaffID, StaffNameKH, StaffNameEN,
        StaffGender, BirthDate, StaffPhone,
        StaffAddress, StaffPosition, Salary,
        HiredDate, IsStopWork, StaffPhoto
    FROM tbStaff
    WHERE (@StaffNameEN IS NULL OR StaffNameEN LIKE '%' + @StaffNameEN + '%')
END
Go
-- Insert into tbSupplier
CREATE PROCEDURE InsertSupplier
    @SupplierID TINYINT,
    @SupplierName VARCHAR(200),
    @SupplierPhone VARCHAR(25),
    @SupplierAddress VARCHAR(255)
AS
BEGIN
    INSERT INTO tbSupplier(SupplierID, SupplierName, SupplierPhone, SupplierAddress)
    VALUES (@SupplierID, @SupplierName, @SupplierPhone, @SupplierAddress)
END;
GO

-- Update tbSupplier
CREATE PROCEDURE UpdateSupplier
    @SupplierID TINYINT,
    @SupplierName VARCHAR(200),
    @SupplierPhone VARCHAR(25),
    @SupplierAddress VARCHAR(255)
AS
BEGIN
    UPDATE tbSupplier
    SET SupplierName = @SupplierName,
        SupplierPhone = @SupplierPhone,
        SupplierAddress = @SupplierAddress
    WHERE SupplierID = @SupplierID;
END;
GO

-- Search tbSupplier by ID (using LIKE)
CREATE PROCEDURE SearchSupplierByID
    @SupplierID VARCHAR(10)
AS
BEGIN
    SELECT * FROM tbSupplier
    WHERE CAST(SupplierID AS VARCHAR) LIKE '%' + @SupplierID + '%';
END;
GO

-- Insert into tbDoctor
CREATE PROCEDURE InsertDoctor
    @DoctorID INT,
    @DoctorName VARCHAR(35),
    @DoctorGender VARCHAR(6),
    @DoctorAddress VARCHAR(255),
    @DoctorBirthDate DATE,
    @DoctorPhone VARCHAR(20),
    @DoctorHiredDate DATE,
    @DoctorPhoto VARBINARY(MAX) = NULL,
    @DoctorSalary MONEY,
    @StoppedWork BIT
AS
BEGIN
    INSERT INTO tbDoctor(DoctorID, DoctorName, DoctorGender, DoctorAddress, DoctorBirthDate, DoctorPhone, DoctorHiredDate, DoctorPhoto, DoctorSalary, StoppedWork)
    VALUES (@DoctorID, @DoctorName, @DoctorGender, @DoctorAddress, @DoctorBirthDate, @DoctorPhone, @DoctorHiredDate, @DoctorPhoto, @DoctorSalary, @StoppedWork);
END;
GO

-- Update tbDoctor
CREATE PROCEDURE UpdateDoctor
    @DoctorID INT,
    @DoctorName VARCHAR(35),
    @DoctorGender VARCHAR(6),
    @DoctorAddress VARCHAR(255),
    @DoctorBirthDate DATE,
    @DoctorPhone VARCHAR(20),
    @DoctorHiredDate DATE,
    @DoctorPhoto VARBINARY(MAX) = NULL,
    @DoctorSalary MONEY,
    @StoppedWork BIT
AS
BEGIN
    UPDATE tbDoctor
    SET DoctorName = @DoctorName,
        DoctorGender = @DoctorGender,
        DoctorAddress = @DoctorAddress,
        DoctorBirthDate = @DoctorBirthDate,
        DoctorPhone = @DoctorPhone,
        DoctorHiredDate = @DoctorHiredDate,
        DoctorPhoto = @DoctorPhoto,
        DoctorSalary = @DoctorSalary,
        StoppedWork = @StoppedWork
    WHERE DoctorID = @DoctorID;
END;
GO

-- Search tbDoctor by DoctorName using LIKE
CREATE PROCEDURE SearchDoctorByName
    @SearchName VARCHAR(50)
AS
BEGIN
    SELECT * FROM tbDoctor
    WHERE DoctorName LIKE '%' + @SearchName + '%';
END;
GO
-- Insert into tbPatient
CREATE PROCEDURE InsertPatient
    @PatientID INT,
    @PatientNameKH NVARCHAR(35),
    @PatientNameEN VARCHAR(25),
    @PatientGender VARCHAR(6),
    @PatientAddress VARCHAR(255),
    @PatientBirthDate DATE,
    @PatientPhone VARCHAR(20),
    @PatientPhoto VARBINARY(MAX) = NULL
AS
BEGIN
    INSERT INTO tbPatient(PatientID, PatientNameKH, PatientNameEN, PatientGender, PatientAddress, PatientBirthDate, PatientPhone, PatientPhoto)
    VALUES (@PatientID, @PatientNameKH, @PatientNameEN, @PatientGender, @PatientAddress, @PatientBirthDate, @PatientPhone, @PatientPhoto);
END;
GO

-- Update tbPatient
CREATE PROCEDURE UpdatePatient
    @PatientID INT,
    @PatientNameKH NVARCHAR(35),
    @PatientNameEN VARCHAR(25),
    @PatientGender VARCHAR(6),
    @PatientAddress VARCHAR(255),
    @PatientBirthDate DATE,
    @PatientPhone VARCHAR(20),
    @PatientPhoto VARBINARY(MAX) = NULL
AS
BEGIN
    UPDATE tbPatient
    SET PatientNameKH = @PatientNameKH,
        PatientNameEN = @PatientNameEN,
        PatientGender = @PatientGender,
        PatientAddress = @PatientAddress,
        PatientBirthDate = @PatientBirthDate,
        PatientPhone = @PatientPhone,
        PatientPhoto = @PatientPhoto
    WHERE PatientID = @PatientID;
END;
GO

-- Search tbPatient by PatientNameEN (using LIKE)
CREATE PROCEDURE SearchPatientByNameEN
    @PatientNameEN VARCHAR(50)
AS
BEGIN
    SELECT * FROM tbPatient
    WHERE PatientNameEN LIKE '%' + @PatientNameEN + '%';
END;



Go
Create Procedure InsertTreatment
    @TreatmentID INT,
    @TreatmentName VARCHAR(25),
    @TreatmentDate DATE,
    @PatientID INT,
    @DoctorID INT,
    @PatientNameKH nvarchar(35), 
    @PatientNameEN varchar(25),
    @DoctorName NVARCHAR(35)
AS
BEGIN
  SET NOCOUNT ON
    INSERT INTO tbTreatment (TreatmentID, TreatmentName, TreatmentDate, 
        PatientID, PatientNameKH, PatientNameEN, DoctorID, DoctorName)
    VALUES (@TreatmentID, @TreatmentName, @TreatmentDate, @PatientID,
        @PatientNameKH, @PatientNameEN , @DoctorID, @DoctorName);
END

GO
CREATE PROCEDURE UpdateTreatment
    @TreatmentID INT,
    @TreatmentName VARCHAR(25),
    @TreatmentDate DATE,
    @PatientID INT,
    @PatientNameKH NVARCHAR(35),
    @PatientNameEN VARCHAR(25),
    @DoctorID INT,
    @DoctorName NVARCHAR(35)
AS
BEGIN
    UPDATE tbTreatment
    SET
        TreatmentName = @TreatmentName,
        TreatmentDate = @TreatmentDate,
        PatientID = @PatientID,
        PatientNameKH = @PatientNameKH,
        PatientNameEN = @PatientNameEN,
        DoctorID = @DoctorID,
        DoctorName = @DoctorName
    WHERE
        TreatmentID = @TreatmentID;
END


Go
Create Procedure InsertTreatmentDetail
    @TreatmentID INT,
    @DiseaseID INT,
    @DiseaseName NVARCHAR(35),
    @TreatmentMethod VARCHAR(100),
    @Duration TIME
AS
BEGIN
  SET NOCOUNT ON
    INSERT INTO tbTreatmentDetail
  VALUES (@TreatmentID, @DiseaseID, @DiseaseName, @TreatmentMethod, @Duration);
END

Go
Create Procedure UpdateTreatmentDetail
    @TreatmentID INT,
    @DiseaseID INT,
    @DiseaseName NVARCHAR(35),
    @TreatmentMethod VARCHAR(100),
    @Duration TIME
AS
BEGIN
  SET NOCOUNT ON
    Update tbTreatmentDetail 
  Set 
    TreatmentID = @TreatmentID, 
    DiseaseID = @DiseaseID,
    DiseaseName = @DiseaseName,
    TreatmentMethod = @TreatmentMethod,
    Duration = @Duration
  WHERE 
  TreatmentID = @TreatmentID AND DiseaseID = @DiseaseID;
END

Go
Create Procedure SearchTrearmentByID  @TreatmentID NVARCHAR(50)
AS
BEGIN
    SELECT * FROM tbTreatmentDetail
    WHERE CAST(TreatmentID AS NVARCHAR(50)) LIKE '%' + @TreatmentID + '%'
END

Go
CREATE PROCEDURE spInsertAppointment
    @AppointmentID int,
    @AppointmentDate date,
    @AppointmentStatus varchar(35),
    @PatientID int,
	@PatientNameKH nvarchar(35),
	@PatientNameEN varchar(25),
    @DoctorID int,
	@DoctorName varchar(35),
    @Duration time
AS
BEGIN
    INSERT INTO tbAppointment(AppointmentID, AppointmentDate, AppointmentStatus, PatientID, DoctorID, Duration)
    VALUES (@AppointmentID, @AppointmentDate, @AppointmentStatus,
            @PatientID, @DoctorID, @Duration)
END


Go
CREATE PROCEDURE spUpdateAppointment
    @AppointmentID int,
    @AppointmentDate date,
    @AppointmentStatus varchar(35),
    @PatientID int,
	@PatientNameKH nvarchar(35),
	@PatientNameEN varchar(25),
    @DoctorID int,
	@DoctorName varchar(35),
    @Duration time
AS
BEGIN
    UPDATE tbAppointment
    SET AppointmentDate = @AppointmentDate,
        AppointmentStatus = @AppointmentStatus,
        PatientID = @PatientID,
		PatientNameKH = @PatientNameKH,
		PatientNameEN = @PatientNameEN,
        DoctorID = @DoctorID,
		DoctorName = @DoctorName,
        Duration = @Duration
    WHERE AppointmentID = @AppointmentID
END

Go
Create PROCEDURE spSearchAppointmentByID  
    @AppointmentID NVARCHAR(50)
AS
BEGIN
    SELECT * 
    FROM tbAppointment
    WHERE CAST(AppointmentID AS NVARCHAR(50)) LIKE '%' + @AppointmentID + '%'
END

Go
CREATE PROCEDURE spInsertImport
    @ImportID bigint,
    @ImportDate date,
    @SupplierID tinyint,
	@SupplierName varchar(200), 
    @StaffID smallint,
    @StaffNameEN varchar(25),
	@StaffNameKH nvarchar(35),
    @StaffPosition varchar(150),
    @TotalAmount money
AS
BEGIN
    INSERT INTO tbImport(ImportID, ImportDate, SupplierID,SupplierName, StaffID, StaffNameEN, StaffNameKH, StaffPosition,TotalAmount)
    VALUES (@ImportID, @ImportDate, @SupplierID,@SupplierName, @StaffID, @StaffNameEN,@StaffNameKH, @StaffPosition, @TotalAmount)
END

Go
CREATE PROCEDURE spUpdateImport
    @ImportID bigint,
    @ImportDate date,
    @SupplierID tinyint,
	@SupplierName varchar(200),
    @StaffID smallint,
    @StaffNameEN varchar(25),
	@StaffNameKH nvarchar(35),
    @StaffPosition varchar(150),
    @TotalAmount money
AS
BEGIN
    UPDATE tbImport
    SET ImportDate = @ImportDate,
        SupplierID = @SupplierID,
		SupplierName = @SupplierName,
        StaffID = @StaffID,
	    StaffNameEN = @StaffNameEN,
		StaffNameKH = @StaffNameKH,
        StaffPosition = @StaffPosition,
        TotalAmount = @TotalAmount
    WHERE ImportID = @ImportID
END

Go
CREATE PROCEDURE spSearchImportByID  
    @ImportID NVARCHAR(50)
AS
BEGIN
    SELECT * 
    FROM tbImportDetail
    WHERE CAST(ImportID AS NVARCHAR(50)) LIKE '%' + @ImportID + '%'
END

Go
CREATE PROCEDURE spInsertImportDetail
    @ImportID bigint,
    @MedicineStockID int,
	@MedicineStockName nvarchar(200),
    @ImportQty smallint,
    @ImportUnitPrice money,
    @ImportAmount money
AS
BEGIN
    INSERT INTO tbImportDetail
    VALUES (@ImportID, @MedicineStockID, @MedicineStockName, @ImportQty, @ImportUnitPrice, @ImportAmount)
END

GO
CREATE PROCEDURE spUpdateImportDetail
    @ImportID bigint,
    @MedicineStockID int,
	@MedicineStockName nvarchar(200),
    @ImportQty smallint,
    @ImportUnitPrice money,
    @ImportAmount money
AS
BEGIN
    UPDATE tbImportDetail
    SET ImportQty = @ImportQty,
        ImportUnitPrice = @ImportUnitPrice,
        ImportAmount = @ImportAmount,
		MedicineStockName = @MedicineStockName
    WHERE ImportID = @ImportID AND MedicineStockID = @MedicineStockID
END


Go
CREATE PROCEDURE InsertPayment
    @PaymentID INT,
    @PayDate DATE,
    @PaidAmount MONEY,
	@PaymentMethod VARCHAR(50),
    @PatientID INT,
    @StaffID INT,
	@StaffNameKH nvarchar(35),
    @StaffNameEN varchar(25),
	@StaffPosition varchar(150)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tbPayment (PaymentID, PayDate, PaidAmount,PaymentMethod, PatientID, StaffID, StaffNameKH, StaffNameEN, StaffPosition)
    VALUES (@PaymentID, @PayDate, @PaidAmount,@PaymentMethod, @PatientID, @StaffID, @StaffNameKH, @StaffNameEN, @StaffPosition);
END


GO
CREATE PROCEDURE UpdatePayment
    @PaymentID INT,
    @PayDate DATE,
    @PaidAmount MONEY,
	@PaymentMethod VARCHAR(50),
    @PatientID INT,
    @StaffID INT,
	@StaffNameKH nvarchar(35),
    @StaffNameEN varchar(25),
	@StaffPosition varchar(150)
AS
BEGIN
    UPDATE tbPayment
    SET
        PayDate = @PayDate,
        PaidAmount = @PaidAmount,
        PatientID = @PatientID,
		PaymentMethod = @PaymentMethod,
        StaffID = @StaffID,
		StaffNameKH = @StaffNameKH,
		StaffNameEN = @StaffNameEN,
		StaffPosition =@StaffPosition
    WHERE
        PaymentID = @PaymentID;
END


GO
CREATE PROCEDURE SearchPaymentByID
    @PaymentID NVARCHAR(50)
AS
BEGIN
    SELECT * FROM tbPayment
    WHERE CAST(PaymentID AS NVARCHAR(50)) LIKE '%' + @PaymentID + '%';
END


Go
CREATE PROCEDURE InsertOrder
    @OrderID INT,
    @OrderDate DATE,
    @SupplierID tinyint, 
    @SupplierName varchar(200),
    @StaffID smallint,
    @StaffNameKH NVarchar(35),
	@StaffNameEN Varchar(25),
	@StaffPosition varchar(150),
    @TotalAmount DECIMAL(10,2)
AS
BEGIN
  SET NOCOUNT ON
    INSERT INTO tbOrder (OrderID, OrderDate, StaffID,StaffNameKH, StaffNameEN, SupplierID, SupplierName,StaffPosition, TotalAmount)
    VALUES ( @OrderID, @OrderDate, @StaffID,@StaffNameKH, @StaffNameEN, @SupplierID,@SupplierName,@StaffPosition, @TotalAmount);
END;


Go
CREATE PROCEDURE UpdateOrder
    @OrderID INT,
    @OrderDate DATE,           
    @StaffID smallint,
    @StaffNameKH Nvarchar(35),
    @StaffNameEN varchar(25),
    @SupplierID tinyint,
    @SupplierName varchar(200),
	@StaffPosition varchar(150),
    @TotalAmount DECIMAL(10,2)
AS
BEGIN
    UPDATE tbOrder
    SET
        OrderDate = @OrderDate,
        StaffID = @StaffID,
        StaffNameKH =@StaffNameKH,
		StaffNameEN = @StaffNameEN,
        SupplierID = @SupplierID,
        SupplierName = @SupplierName,
		StaffPosition = @StaffPosition,
        TotalAmount = @TotalAmount
    WHERE
        OrderID = @OrderID;
END;


Go
CREATE PROCEDURE UpdateOrderDetail
    @OrderID INT,
    @MedicineStockID INT,
    @MedicineStockName varchar(200),
    @Quantity INT,
    @UnitPrice DECIMAL(10,2),
    @SubTotal DECIMAL(10,2)
AS
BEGIN
  SET NOCOUNT ON
    UPDATE tbOrderDetail
    SET
        Quantity = @Quantity,
        UnitPrice = @UnitPrice,
        SubTotal = @SubTotal
    WHERE
        OrderID = @OrderID AND
        MedicineStockID = @MedicineStockID;
END;


Go
CREATE PROCEDURE InsertOrderDetail
    @OrderID INT,
    @MedicineStockID INT,
    @MedicineStockName varchar(200),
    @Quantity INT,
    @UnitPrice DECIMAL(10,2),
    @SubTotal DECIMAL(10,2)
AS
BEGIN
  SET NOCOUNT ON
    INSERT INTO tbOrderDetail (OrderID, MedicineStockID,MedicineStockName, Quantity, UnitPrice, SubTotal)
    VALUES ( @OrderID, @MedicineStockID, @MedicineStockName, @Quantity, @UnitPrice, @SubTotal );
END;

Go
Create Procedure SearchOrderByID  @OrderID NVARCHAR(50)
AS
BEGIN
    SELECT * FROM tbOrderDetail
    WHERE CAST(OrderID AS NVARCHAR(50)) LIKE '%' + @OrderID + '%'
END
Go
Create Procedure InsertPrescription
    @PrescriptionID INT,
    @Diagnosis varchar(100),
    @DateIssue DATE,
    @PatientID INT,
    @PatientNameKH nvarchar(35), 
    @PatientNameEN varchar(25),
    @DoctorID INT,
    @DoctorName VARCHAR(35)
AS
BEGIN
  SET NOCOUNT ON
    INSERT INTO tbPrescription(
		PrescriptionID, Diagnosis, DateIssued, 
		PatientID, PatientNameKH, PatientNameEN,
		DoctorID, DoctorName
	)VALUES (
		@PrescriptionID, @Diagnosis, @DateIssue, 
		@PatientID, @PatientNameKH, @PatientNameEN , 
		@DoctorID, @DoctorName);
END


GO
CREATE PROCEDURE UpdatePrescription
    @PrescriptionID INT,
    @Diagnosis varchar(100),
    @DateIssue DATE,
    @PatientID INT,
    @PatientNameKH nvarchar(35), 
    @PatientNameEN varchar(25),
    @DoctorID INT,
    @DoctorName VARCHAR(35)
AS
BEGIN
    UPDATE tbPrescription
    SET
        Diagnosis = @Diagnosis,
        DateIssued = @DateIssue,
        PatientID = @PatientID,
        PatientNameKH = @PatientNameKH,
        PatientNameEN = @PatientNameEN,
        DoctorID = @DoctorID,
        DoctorName = @DoctorName
    WHERE
        PrescriptionID = @PrescriptionID;
END



GO
Create Procedure InsertPrescriptionDetail
    @PrescriptionID INT,
    @DiseaseID INT,
    @DiseaseName varchar(35),
    @TreatmentMethod Varchar(100),
    @Duration time
AS
BEGIN
  SET NOCOUNT ON
    INSERT INTO tbPrescriptionDetail(
    PrescriptionID, 
    DiseaseID,
    DiseaseName,
    TreatmentMethod,
    Duration
  ) 
  VALUES (
    @PrescriptionID, 
    @DiseaseID,
    @DiseaseName,
    @TreatmentMethod,
    @Duration
  );
END


GO
CREATE PROCEDURE UpdatePrescriptionDetail
    @PrescriptionID INT,
	@DiseaseID INT,
	@DiseaseName varchar(35),
	@TreatmentMethod Varchar(100),
	@Duration time
AS
BEGIN
    UPDATE tbPrescriptionDetail
    SET
    PrescriptionID = @PrescriptionID,
    DiseaseID = @DiseaseID,
    DiseaseName = @DiseaseName,
    TreatmentMethod = @TreatmentMethod,
    Duration = @Duration
    WHERE
        PrescriptionID = @PrescriptionID AND DiseaseID = @DiseaseID
END


Go
Create Procedure SearchPrescriptionByID  @PrescriptionID NVARCHAR(50)
AS
BEGIN
    SELECT * FROM tbPrescriptionDetail
    WHERE CAST(PrescriptionID AS NVARCHAR(50)) LIKE '%' + @PrescriptionID + '%'
END

GO
CREATE PROCEDURE spInsertDisease
  @DiseaseID INT, @DiseaseName varchar(35), @DiseaseCategory varchar(100)
AS
BEGIN 
  SET NOCOUNT ON
  INSERT INTO tbDisease(
    DiseaseID,
    DiseaseName,
    DiseaseCategory
  )
  VALUES(
    @DiseaseID,
    @DiseaseName,
    @DiseaseCategory
  )
END

GO
CREATE PROCEDURE spUpdateDisease
  @DiseaseID INT, @DiseaseName varchar(35), @DiseaseCategory varchar(100)
AS
BEGIN 
  SET NOCOUNT ON
  UPDATE tbDisease
  SET
    DiseaseName = @DiseaseName,
    DiseaseCategory = @DiseaseCategory
  WHERE DiseaseID = @DiseaseID
END


GO
Create Procedure SearchDiseaseByID  @DiseaseID NVARCHAR(50)
AS
BEGIN
    SELECT * FROM tbDisease
    WHERE CAST(DiseaseID AS NVARCHAR(50)) LIKE '%' + @DiseaseID + '%'
END


GO
Create Procedure spInsertMedicineStock
  @MedicineStockID INT,
  @MedicineStockName varchar(200),
  @Category varchar(150),
  @StockQty Smallint,
  @UnitPrice Money
AS
BEGIN
  Set nocount on
  Insert Into tbMedicineStock(
    MedicineStockID,
    MedicineStockName,
    Category,
    StockQty,
    UnitPrice
  ) 
  Values (
    @MedicineStockID,
    @MedicineStockName,
    @Category,
    @StockQty,
    @UnitPrice
  )
END

GO
Create Procedure spUpdateMedicineStock
  @MedicineStockID INT,
  @MedicineStockName varchar(200),
  @Category varchar(150),
  @StockQty Smallint,
  @UnitPrice Money
AS
BEGIN
  SET NOCOUNT ON
  UPDATE tbMedicineStock
  SET
    MedicineStockName = @MedicineStockName,
    Category = @Category,
    StockQty = @StockQty,
    UnitPrice = @UnitPrice
  WHERE MedicineStockID = @MedicineStockID
END

Go 
Create Procedure SearchMedicineStockByID  @MedicineStockID NVARCHAR(50)
AS
BEGIN
    SELECT * FROM tbMedicineStock
    WHERE CAST(MedicineStockID AS NVARCHAR(50)) LIKE '%' + @MedicineStockID + '%'
END



----------------------------------------------------------------------------
