module App

open Browser.Dom

type Ingredient =
    {
        Name: string
        Category: string
        Unit: string
        PricePerUnit: float
        Supplier: string
    }

type RecipeIngredient =
    {
        IngredientName: string
        Quantity: float
    }

type Recipe =
    {
        Name: string
        Category: string
        Portions: int
        Ingredients: RecipeIngredient list
    }

let ingredients =
    [
        { Name = "Chicken"; Category = "Meat"; Unit = "kg"; PricePerUnit = 5.50; Supplier = "Local Butcher" }
        { Name = "Rice"; Category = "Dry Goods"; Unit = "kg"; PricePerUnit = 2.20; Supplier = "Wholesale Foods" }
        { Name = "Tomato"; Category = "Vegetable"; Unit = "kg"; PricePerUnit = 3.10; Supplier = "Fresh Farm Produce" }
        { Name = "Pasta"; Category = "Dry Goods"; Unit = "kg"; PricePerUnit = 1.80; Supplier = "Wholesale Foods" }
        { Name = "Potato"; Category = "Vegetable"; Unit = "kg"; PricePerUnit = 1.25; Supplier = "Fresh Farm Produce" }
        { Name = "Carrot"; Category = "Vegetable"; Unit = "kg"; PricePerUnit = 1.10; Supplier = "Fresh Farm Produce" }
        { Name = "Onion"; Category = "Vegetable"; Unit = "kg"; PricePerUnit = 0.95; Supplier = "Fresh Farm Produce" }
        { Name = "Cheese"; Category = "Dairy"; Unit = "kg"; PricePerUnit = 6.40; Supplier = "Dairy Direct" }
        { Name = "Egg"; Category = "Dairy"; Unit = "piece"; PricePerUnit = 0.25; Supplier = "Dairy Direct" }
        { Name = "Beef"; Category = "Meat"; Unit = "kg"; PricePerUnit = 8.90; Supplier = "Local Butcher" }
        { Name = "Milk"; Category = "Dairy"; Unit = "litre"; PricePerUnit = 1.35; Supplier = "Dairy Direct" }
        { Name = "Flour"; Category = "Dry Goods"; Unit = "kg"; PricePerUnit = 1.15; Supplier = "Wholesale Foods" }
    ]

let recipes =
    [
        {
            Name = "Chicken Rice Bowl"
            Category = "Main Course"
            Portions = 10
            Ingredients =
                [
                    { IngredientName = "Chicken"; Quantity = 2.0 }
                    { IngredientName = "Rice"; Quantity = 1.5 }
                    { IngredientName = "Tomato"; Quantity = 1.0 }
                    { IngredientName = "Onion"; Quantity = 0.3 }
                ]
        }

        {
            Name = "Tomato Pasta"
            Category = "Main Course"
            Portions = 12
            Ingredients =
                [
                    { IngredientName = "Pasta"; Quantity = 1.8 }
                    { IngredientName = "Tomato"; Quantity = 2.0 }
                    { IngredientName = "Onion"; Quantity = 0.4 }
                    { IngredientName = "Cheese"; Quantity = 0.5 }
                ]
        }

        {
            Name = "Vegetable Soup"
            Category = "Starter"
            Portions = 15
            Ingredients =
                [
                    { IngredientName = "Potato"; Quantity = 1.5 }
                    { IngredientName = "Carrot"; Quantity = 1.2 }
                    { IngredientName = "Onion"; Quantity = 0.5 }
                    { IngredientName = "Milk"; Quantity = 1.0 }
                ]
        }

        {
            Name = "Cheese Omelette"
            Category = "Main Course"
            Portions = 8
            Ingredients =
                [
                    { IngredientName = "Egg"; Quantity = 16.0 }
                    { IngredientName = "Cheese"; Quantity = 0.6 }
                    { IngredientName = "Milk"; Quantity = 0.5 }
                ]
        }

        {
            Name = "Beef Stew"
            Category = "Main Course"
            Portions = 10
            Ingredients =
                [
                    { IngredientName = "Beef"; Quantity = 2.2 }
                    { IngredientName = "Potato"; Quantity = 2.0 }
                    { IngredientName = "Carrot"; Quantity = 1.0 }
                    { IngredientName = "Onion"; Quantity = 0.6 }
                ]
        }

        {
            Name = "Potato Bake"
            Category = "Side Dish"
            Portions = 12
            Ingredients =
                [
                    { IngredientName = "Potato"; Quantity = 3.0 }
                    { IngredientName = "Cheese"; Quantity = 0.7 }
                    { IngredientName = "Milk"; Quantity = 1.0 }
                    { IngredientName = "Flour"; Quantity = 0.2 }
                ]
        }
    ]

let findIngredient name =
    ingredients
    |> List.tryFind (fun ingredient -> ingredient.Name = name)

let calculateIngredientCost recipeIngredient =
    match findIngredient recipeIngredient.IngredientName with
    | Some ingredient -> recipeIngredient.Quantity * ingredient.PricePerUnit
    | None -> 0.0

let calculateRecipeCost recipe =
    recipe.Ingredients
    |> List.sumBy calculateIngredientCost

let calculateCostPerPortion recipe =
    calculateRecipeCost recipe / float recipe.Portions

let totalRecipeCost =
    recipes
    |> List.sumBy calculateRecipeCost

let averageCostPerPortion =
    recipes
    |> List.averageBy calculateCostPerPortion

let currency value =
    sprintf "£%.2f" value

let appContainer =
    document.querySelector("#app")

let dashboardHtml =
    sprintf
        """
        <section class="dashboard">
            <div class="stat-card">
                <span class="stat-label">Ingredients</span>
                <strong>%i</strong>
            </div>

            <div class="stat-card">
                <span class="stat-label">Recipes</span>
                <strong>%i</strong>
            </div>

            <div class="stat-card">
                <span class="stat-label">Total Recipe Cost</span>
                <strong>%s</strong>
            </div>

            <div class="stat-card">
                <span class="stat-label">Average Cost / Portion</span>
                <strong>%s</strong>
            </div>
        </section>
        """
        ingredients.Length
        recipes.Length
        (currency totalRecipeCost)
        (currency averageCostPerPortion)

let ingredientHtml =
    ingredients
    |> List.map (fun ingredient ->
        sprintf
            """
            <div class="card">
                <div class="card-header">
                    <h3>%s</h3>
                    <span>%s</span>
                </div>
                <p><strong>Unit:</strong> %s</p>
                <p><strong>Price per unit:</strong> %s</p>
                <p><strong>Supplier:</strong> %s</p>
            </div>
            """
            ingredient.Name
            ingredient.Category
            ingredient.Unit
            (currency ingredient.PricePerUnit)
            ingredient.Supplier)
    |> String.concat ""

let recipeIngredientHtml recipe =
    recipe.Ingredients
    |> List.map (fun item ->
        match findIngredient item.IngredientName with
        | Some ingredient ->
            sprintf
                "<li>%s: %.2f %s - %s</li>"
                item.IngredientName
                item.Quantity
                ingredient.Unit
                (currency (calculateIngredientCost item))
        | None ->
            sprintf "<li>%s: ingredient not found</li>" item.IngredientName)
    |> String.concat ""

let recipeHtml =
    recipes
    |> List.map (fun recipe ->
        sprintf
            """
            <div class="card recipe-card">
                <div class="card-header">
                    <h3>%s</h3>
                    <span>%s</span>
                </div>

                <p><strong>Portions:</strong> %i</p>
                <p><strong>Total cost:</strong> %s</p>
                <p><strong>Cost per portion:</strong> %s</p>

                <h4>Ingredients</h4>
                <ul>
                    %s
                </ul>
            </div>
            """
            recipe.Name
            recipe.Category
            recipe.Portions
            (currency (calculateRecipeCost recipe))
            (currency (calculateCostPerPortion recipe))
            (recipeIngredientHtml recipe))
    |> String.concat ""

appContainer.innerHTML <-
    sprintf
        """
        <div class="page">
            <header class="hero">
                <div>
                    <p class="eyebrow">Kitchen planning made clearer</p>
                    <h1>MealForge</h1>
                    <p class="subtitle">
                        Menu planning and food cost calculation for school kitchens,
                        small restaurants, and catering teams.
                    </p>
                </div>
            </header>

            %s

            <section>
                <div class="section-title">
                    <h2>Ingredients</h2>
                    <p>Basic stock items with prices, units, categories, and suppliers.</p>
                </div>

                <div class="grid">
                    %s
                </div>
            </section>

            <section>
                <div class="section-title">
                    <h2>Recipes</h2>
                    <p>Each recipe calculates total cost and estimated cost per portion.</p>
                </div>

                <div class="grid">
                    %s
                </div>
            </section>
        </div>
        """
        dashboardHtml
        ingredientHtml
        recipeHtml