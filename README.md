# wpf-app-meteo

**FR** — Application météo de bureau **WPF (.NET 6, C#)** : consultation des prévisions par région, avec persistance locale, interface bilingue et installateur Windows.

**EN** — A **WPF (.NET 6, C#)** desktop weather app: browse forecasts by region, with local persistence, a bilingual UI and a Windows installer.

---

## Fonctionnalités / Features

- **FR**
  - Architecture **MVVM** (ViewModels, commandes, convertisseurs d'icônes météo).
  - Persistance via **Entity Framework Core** (contexte + migrations).
  - **Injection de dépendances** (`FournisseurDI`).
  - Interface **bilingue FR/EN** (ressources localisées).
  - Appel d'une **API météo REST** (réponse désérialisée en modèles typés).
  - Tests unitaires (`Tp_Final_Fred.Tests`) et **installateur NSIS**.
- **EN**
  - **MVVM** architecture (ViewModels, commands, weather-icon converters).
  - Persistence with **Entity Framework Core** (context + migrations).
  - **Dependency injection** (`FournisseurDI`).
  - **Bilingual FR/EN** UI (localized resources).
  - Calls a **REST weather API** (response deserialized into typed models).
  - Unit tests (`Tp_Final_Fred.Tests`) and an **NSIS installer**.

## Stack

C# · .NET 6 · WPF · Entity Framework Core · xUnit/MSTest · NSIS.

## Configuration

**FR** : la clé API météo se saisit dans la fenêtre de configuration de l'application (stockée localement, jamais dans le dépôt). Un exemple est fourni dans `config.example.json`.

**EN**: the weather API key is entered in the app's configuration window (stored locally, never committed). See `config.example.json` for the expected format.

```bash
# Ouvrir la solution dans Visual Studio 2022, puis F5
# ou en ligne de commande :
dotnet run --project Tp_Final_Fred
```
