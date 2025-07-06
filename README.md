# BartenderCheatSheet 🍸

> A project built with ASP.NET Core, powered by the public [TheCocktailDB](https://www.thecocktaildb.com/) API. This app features search and ingredient-based filtering.

---

## 🎯 Project Purpose

This app was created to:

- develop a functional MVP using public external APIs,
- demonstrate how to process and normalize non-ideal external data structures (e.g. `strIngredient1–15`),
- practice clean architecture patterns: DTOs, service layers, domain modeling, filtering logic,
- showcase engineering skills in handling real-world API limitations (like lack of multi-ingredient search),
- create a fun, visual project suitable for a portfolio without compromising on code quality.

---
## 💻 Tech Stack
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core%20MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![TheCocktailDB](https://img.shields.io/badge/TheCocktailDB-FF6347?style=for-the-badge&logo=glassdoor&logoColor=white)
![JSON](https://img.shields.io/badge/JSON-000000?style=for-the-badge&logo=json&logoColor=white)

- **ASP.NET Core MVC**: Enables clean separation of concerns between models, views and controllers.
- **C#**: Primary programming language for backend and domain logic.
- **TheCocktailDB API**: External data source for cocktails, ingredients and images.
- **JSON**: Data exchange format used when consuming the external API.
---

## 📸 Screenshots

<div style="display:flex; justify-content:center;">
  <img src="https://github.com/MikolajMal/BartenderCheatSheet/blob/main/Screenshots/Home.png" width="600" />
  <img src="https://github.com/MikolajMal/BartenderCheatSheet/blob/main/Screenshots/SearchByName.png" width="600" />
  <img src="https://github.com/MikolajMal/BartenderCheatSheet/blob/main/Screenshots/SearchByIngredient.png" width="600" />
</div>

---

## 🔍 Key Features

- Filter cocktails by one or more ingredients
- Discover random drinks
- View detailed recipes with images, ingredients, proportions and instructions

---
