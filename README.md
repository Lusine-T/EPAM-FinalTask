# Ecommerce Test Automation Project

This project contains automated tests for the E-commerce website: [https://practice.qabrains.com/ecommerce](https://practice.qabrains.com/ecommerce)

## Task Description

The goal of this project is to implement an automated test suite covering the following user stories:

### UC-1: Test Login form with wrong credentials

*   **Objective:** Verify that the login form correctly handles invalid credentials and displays appropriate error messages.
*   **Steps:**
    *   Enter credentials that are not listed in the "Accepted email" and "Password" sections into the "Email" and "Password" fields.
    *   Hit the "Login" button.
    *   Check for the error messages: "Username is incorrect" and "Password is incorrect." (or similar messages for empty fields/wrong formats).

### UC-2: Test favorite products

*   **Objective:** Verify that users can mark items as favorites and that these items are correctly displayed on the Favorites page.
*   **Steps:**
    *   Enter valid credentials from the "Accepted email" and "Password" sections into the "Email" and "Password" fields.
    *   Mark a few items as favorites from the products listing.
    *   Click on the email in the top right corner and navigate to "Favorites".
    *   Check that the previously selected items are displayed on the Favorites page.

### UC-3: Test products ordering

*   **Objective:** Verify that products can be ordered by price from low to high and that the ordering is correct.
*   **Steps:**
    *   Enter valid credentials from the "Accepted email" and "Password" sections into the "Email" and "Password" fields.
    *   Order products by price from low to high.
    *   Check that all products are ordered according to the selected option.

## General Requirements

*   **Test Automation Tool:** Selenium WebDriver
*   **Browsers:** Chrome, Edge 
*   **Locators:** XPath
*   **Test Runner:** xUnit
*   **Parallel Execution:** Tests should be executable in parallel.
*   **Logging:** Add logging to track execution flow.
*  
## Project Structure

*   `EcommerceTests.Core`: Contains core components like `DriverManager`, `Config`, `LogHelper`.
*   `EcommerceTests.Models`: Contains data models (e.g., `User`).
*   `EcommerceTests.Builders`: Contains builder patterns (e.g., `UserBuilder`).
*   `EcommerceTests.PageObjects`: Contains Page Object models for web pages (e.g., `LoginPage`, `ProductsPage`, `FavoritesPage`).
*   `EcommerceTests.Tests`: Contains the actual test cases (e.g., `LoginTests`, `ProductsPageTest`).

## How to Run Tests

1.  **Restore NuGet packages:**
    ```bash
    dotnet restore
    ```
2.  **Run tests:**
    ```bash
    dotnet test
    ```
