# Seam Carving Image Resizer – Windows Forms Application

A Windows Forms application written in C# that implements the **Seam Carving** content-aware image resizing algorithm, with support for object removal and undo/redo functionality.

---

## 📌 Project Overview

This application allows users to resize images intelligently by removing or adding pixels along the least important paths (“seams”) in the image. It also supports marking objects for removal and includes full undo/redo capabilities.

**Key features:**
- Content-aware image resizing (width/height reduction)
- Object removal via manual masking
- Undo/redo operations (Ctrl+Z / Ctrl+U)
- Energy map visualization
- Multithreaded processing with progress bar
- Drag-and-drop image loading

---

## 🧠 Algorithm Overview

The Seam Carving algorithm consists of three main steps:

### 1. Energy Calculation
Each pixel’s energy is computed based on color differences with neighboring pixels. Higher energy means the pixel is more important (e.g., edges, details).

Formula used:

$$E(x, y) = \left|\frac{\partial I}{\partial x}\right| + \left|\frac{\partial I}{\partial y}\right|$$

### 2. Finding the Optimal Seam
A dynamic programming approach is used to find the connected path of pixels (vertical or horizontal) with the minimum total energy.

$$
s[i,j] = 
\begin{cases} 
e[i,j] & i = 0 \\
e[i,j] + \min(s[i-1,j-1], s[i-1,j], s[i-1,j+1]) & i \neq 0 
\end{cases}
$$

### 3. Removing or Duplicating the Seam
- To **reduce** size: the seam is removed.
- To **enlarge** size: the seam is duplicated (with stretching).

The algorithm can also be used for object removal by assigning negative energy to selected regions.

---

## 🖥️ User Interface

The main window includes:
- `PictureBox` for image display and interactive masking
- Menu bar (`Open`, `Save`)
- Controls for setting target width/height (`NumericUpDown`)
- `Apply` button to start processing
- `GrayImage` button to view the energy map
- Progress bar for long operations
- Support for drag-and-drop image loading

### Masking Tool
Users can draw red rectangles over objects they wish to remove. The marked regions are given low priority during seam carving.

---

## 🏗️ Design Patterns

Two main design patterns were implemented:

### 1. **MVC (Model-View-Controller)**
- **Model** (`Model.cs`): Contains core logic for seam carving and image processing.
- **View** (`Form1.cs`): Handles UI rendering and user interactions.
- **Controller** (`Controller.cs`): Mediates between Model and View, manages commands and state.

### 2. **Command Pattern**
- Used to implement undo/redo functionality.
- Each image modification is encapsulated as a command.
- Supports `Ctrl+Z` (undo) and `Ctrl+U` (redo).

---

## 📂 Project Structure
SeamCarvingApp/
│
├── Form1.cs # Main window UI
├── Controller.cs # Controller (MVC)
├── Model.cs # Model (MVC)
├── LiquidResize.cs # Core seam carving logic
├── ImgMask.cs # Mask handling for object removal
├── Command/
│ └── ICommand.cs # Interface for commands
│ └── ImageCommand.cs # Concrete command implementations
│
└── Resources/ # Icons and sample images

---

## 🚀 How to Use

1. **Open an image** via `File → Open` or drag-and-drop.
2. **Mark objects to remove** by drawing red rectangles on the image.
3. **Set desired width/height** using the numeric controls.
4. Click **Apply** to run the seam carving algorithm.
5. Use **GrayImage** to view the energy map.
6. Save the result via `File → Save`.
7. Use **Ctrl+Z** to undo and **Ctrl+U** to redo changes.

---

## 📸 Example Results

*(Examples from the report show effective removal of seams and objects while preserving important visual content.)*

| Original | After Seam Carving (Width Reduced) |
|----------|-------------------------------------|
| ![Original](https://i.imgur.com/UJhuDIN.png) | ![Result](https://i.imgur.com/lgo3bJr.png) |

---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET Windows Forms
- **Image Processing:** Custom implementation based on Seam Carving
- **Multithreading:** `BackgroundWorker` for non-blocking UI
- **Design Patterns:** MVC, Command

---

## 📄 License

Academic project – developed as part of the **Object-Oriented Programming** course at Moscow Aviation Institute (MAI), 2021.

---


*This project demonstrates practical application of algorithms and design patterns in a graphical desktop application.*
