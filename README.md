
# Baobab Ridge Wildlife Rehabilitation Records System

## Project Description
A C# Windows Forms application for managing animal rehabilitation records at Baobab Ridge Wildlife Rehabilitation Centre.

## Group Members
- Person 1: Keodirile Rihlampfu - 604891
- Person 2:Nombuyiselo Vilakazi - 603732
- Person 3: Momelazi Tyini - 602059
- Person 4: Hendrik Steyl - 603477

## Technologies
- C#
- Windows Forms
- .NET 8.0 or newer
- Git and GitHub
- Plain text file storage

## Features
The application will support adding, viewing, updating and deleting animal records, and generating a summary report.

## Build and Run
Open the solution file in Visual Studio.
Build the solution and run the application.

### Working with the designer (Design view)
This is a Windows Forms project, so the user interface is edited in **Design view**, not by hand.

1. Open `BaobabRidgeWildlifeRecords.slnx` (or `BaobabRidgeWildlifeRecords.csproj`) in Visual Studio.
2. In **Solution Explorer**, find `Form1.cs`.
3. Right-click `Form1.cs` and choose **View Designer** (or select the file and press **Shift + F7**).
4. Use **F7** to switch from Design view to the code, and **Shift + F7** to switch back.
5. Drag controls from the **Toolbox** and edit their properties in the **Properties** window.

The generated layout is stored in `Form1.Designer.cs`. Visual Studio keeps that file in
sync automatically, so it should not be edited manually. If the designer does not appear,
install the **.NET desktop development** workload and use a Visual Studio version that
supports the project's target framework (the project currently targets `.NET 10`).

## File Formats
- animals.txt: Stores animal records as pipe-separated fields.
- summary.txt: Stores the generated animal summary report.

### animals.txt record format
Each line represents one animal and contains exactly seven pipe-separated fields:

```
WR-0001 | Katty | African Elephant | 12 | 85 | Release-Ready | Pre-Release Camp
```

Field order: `Animal ID | Name | Species | Age | Recovery Score | Status | Housing Unit`.

Rules enforced when loading:
- The Animal ID must match the pattern `WR-` followed by four digits (for example `WR-0001`).
- Age and Recovery Score must be whole numbers.
- Status and Housing Unit are derived from the Recovery Score:
  - 0-19 -> Critical / Intensive Care Unit
  - 20-39 -> Serious / High-Dependency Ward
  - 40-59 -> Stable / Recovery Ward
  - 60-79 -> Recovering / Outdoor Enclosure
  - 80-100 -> Release-Ready / Pre-Release Camp
- Lines with the wrong number of fields, a non-numeric Age or Recovery Score, or an
  invalid Animal ID are skipped and the total number skipped is reported once.
- If `animals.txt` is missing it is created empty and the grid simply loads empty.

## Known Limitations
The application is currently under development.
