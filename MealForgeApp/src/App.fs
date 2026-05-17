module App

open Browser.Dom
open Browser.Types
open System

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

type MenuDay =
    {
        DayName: string
        Starter: string
        MainCourse: string
        SideDish: string
        Dessert: string
        PlannedPortions: int
    }

let mutable ingredients =
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
        { Name = "Apple"; Category = "Fruit"; Unit = "kg"; PricePerUnit = 2.40; Supplier = "Fresh Farm Produce" }
        { Name = "Yoghurt"; Category = "Dairy"; Unit = "kg"; PricePerUnit = 3.20; Supplier = "Dairy Direct" }
        { Name = "Lettuce"; Category = "Vegetable"; Unit = "kg"; PricePerUnit = 2.75; Supplier = "Fresh Farm Produce" }
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

        {
            Name = "Garden Salad"
            Category = "Side Dish"
            Portions = 10
            Ingredients =
                [
                    { IngredientName = "Lettuce"; Quantity = 1.0 }
                    { IngredientName = "Tomato"; Quantity = 0.8 }
                    { IngredientName = "Onion"; Quantity = 0.2 }
                ]
        }

        {
            Name = "Apple Yoghurt Bowl"
            Category = "Dessert"
            Portions = 10
            Ingredients =
                [
                    { IngredientName = "Apple"; Quantity = 1.5 }
                    { IngredientName = "Yoghurt"; Quantity = 1.2 }
                ]
        }
    ]

let weeklyMenu =
    [
        { DayName = "Monday"; Starter = "Vegetable Soup"; MainCourse = "Chicken Rice Bowl"; SideDish = "Garden Salad"; Dessert = "Apple Yoghurt Bowl"; PlannedPortions = 50 }
        { DayName = "Tuesday"; Starter = "Vegetable Soup"; MainCourse = "Tomato Pasta"; SideDish = "Potato Bake"; Dessert = "Apple Yoghurt Bowl"; PlannedPortions = 45 }
        { DayName = "Wednesday"; Starter = "Vegetable Soup"; MainCourse = "Beef Stew"; SideDish = "Potato Bake"; Dessert = "Apple Yoghurt Bowl"; PlannedPortions = 55 }
        { DayName = "Thursday"; Starter = "Vegetable Soup"; MainCourse = "Cheese Omelette"; SideDish = "Garden Salad"; Dessert = "Apple Yoghurt Bowl"; PlannedPortions = 40 }
        { DayName = "Friday"; Starter = "Vegetable Soup"; MainCourse = "Chicken Rice Bowl"; SideDish = "Potato Bake"; Dessert = "Apple Yoghurt Bowl"; PlannedPortions = 60 }
    ]

let currency value =
    sprintf "£%.2f" value

let getInputValue id =
    (document.getElementById(id) :?> HTMLInputElement).value.Trim()

let clearInput id =
    (document.getElementById(id) :?> HTMLInputElement).value <- ""

let tryParseFloat text =
    match Double.TryParse(text) with
    | true, value -> Some value
    | false, _ -> None

let findIngredient name =
    ingredients
    |> List.tryFind (fun ingredient -> ingredient.Name = name)

let findRecipe name =
    recipes
    |> List.tryFind (fun recipe -> recipe.Name = name)

let calculateIngredientCost recipeIngredient =
    match findIngredient recipeIngredient.IngredientName with
    | Some ingredient -> recipeIngredient.Quantity * ingredient.PricePerUnit
    | None -> 0.0

let calculateRecipeCost recipe =
    recipe.Ingredients
    |> List.sumBy calculateIngredientCost

let calculateCostPerPortion recipe =
    calculateRecipeCost recipe / float recipe.Portions

let calculateRecipeCostForPortions recipeName plannedPortions =
    match findRecipe recipeName with
    | Some recipe -> calculateCostPerPortion recipe * float plannedPortions
    | None -> 0.0

let calculateMenuDayCost menuDay =
    [ menuDay.Starter; menuDay.MainCourse; menuDay.SideDish; menuDay.Dessert ]
    |> List.sumBy (fun recipeName ->
        calculateRecipeCostForPortions recipeName menuDay.PlannedPortions)

let calculateMenuDayCostPerPerson menuDay =
    calculateMenuDayCost menuDay / float menuDay.PlannedPortions

let weeklyMenuCost =
    weeklyMenu |> List.sumBy calculateMenuDayCost

let totalWeeklyPortions =
    weeklyMenu |> List.sumBy (fun day -> day.PlannedPortions)

let averageDailyMenuCost =
    weeklyMenuCost / float weeklyMenu.Length

let averageCostPerPortion =
    recipes |> List.averageBy calculateCostPerPortion

let appContainer =
    document.querySelector("#app")

let renderDashboard () =
    sprintf
        """
        <section class="dashboard">
            <div class="stat-card"><span class="stat-label">Ingredients</span><strong>%i</strong></div>
            <div class="stat-card"><span class="stat-label">Recipes</span><strong>%i</strong></div>
            <div class="stat-card"><span class="stat-label">Weekly Menu Cost</span><strong>%s</strong></div>
            <div class="stat-card"><span class="stat-label">Weekly Portions</span><strong>%i</strong></div>
            <div class="stat-card"><span class="stat-label">Average Daily Cost</span><strong>%s</strong></div>
            <div class="stat-card"><span class="stat-label">Average Recipe Cost / Portion</span><strong>%s</strong></div>
        </section>
        """
        ingredients.Length
        recipes.Length
        (currency weeklyMenuCost)
        totalWeeklyPortions
        (currency averageDailyMenuCost)
        (currency averageCostPerPortion)

let renderIngredientForm () =
    """
    <section>
        <div class="section-title">
            <h2>Add New Ingredient</h2>
            <p>Add a new stock item to the kitchen ingredient list.</p>
        </div>

        <div class="card">
            <div class="form-grid">
                <input id="ingredient-name" placeholder="Ingredient name" />
                <input id="ingredient-category" placeholder="Category" />
                <input id="ingredient-unit" placeholder="Unit, e.g. kg" />
                <input id="ingredient-price" placeholder="Price per unit, e.g. 2.50" />
                <input id="ingredient-supplier" placeholder="Supplier" />
            </div>

            <button id="add-ingredient-button">Add Ingredient</button>
            <p id="ingredient-message"></p>
        </div>
    </section>
    """

let renderIngredients () =
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

let renderRecipeIngredients recipe =
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

let renderRecipes () =
    recipes
    |> List.map (fun recipe ->
        sprintf
            """
            <div class="card recipe-card">
                <div class="card-header">
                    <h3>%s</h3>
                    <span>%s</span>
                </div>

                <p><strong>Base portions:</strong> %i</p>
                <p><strong>Total base cost:</strong> %s</p>
                <p><strong>Cost per portion:</strong> %s</p>

                <h4>Ingredients</h4>
                <ul>%s</ul>
            </div>
            """
            recipe.Name
            recipe.Category
            recipe.Portions
            (currency (calculateRecipeCost recipe))
            (currency (calculateCostPerPortion recipe))
            (renderRecipeIngredients recipe))
    |> String.concat ""

type ShoppingListItem =
    {
        IngredientName: string
        Unit: string
        TotalQuantity: float
        EstimatedCost: float
    }

let scaleRecipeIngredient plannedPortions recipe (recipeIngredient: RecipeIngredient) =
    let scaleFactor =
        float plannedPortions / float recipe.Portions

    {
        IngredientName = recipeIngredient.IngredientName
        Quantity = recipeIngredient.Quantity * scaleFactor
    }

let getScaledIngredientsForRecipe recipeName plannedPortions =
    match findRecipe recipeName with
    | Some recipe ->
        recipe.Ingredients
        |> List.map (fun item -> scaleRecipeIngredient plannedPortions recipe item)

    | None ->
        []

let getIngredientsForMenuDay menuDay =
    [
        menuDay.Starter
        menuDay.MainCourse
        menuDay.SideDish
        menuDay.Dessert
    ]
    |> List.collect (fun recipeName ->
        getScaledIngredientsForRecipe recipeName menuDay.PlannedPortions)

let generateShoppingList () =
    weeklyMenu
    |> List.collect getIngredientsForMenuDay
    |> List.groupBy (fun (item: RecipeIngredient) -> item.IngredientName)
    |> List.map (fun (ingredientName, items: RecipeIngredient list) ->
        let totalQuantity =
            items |> List.sumBy (fun item -> item.Quantity)

        match findIngredient ingredientName with
        | Some ingredient ->
            {
                IngredientName = ingredientName
                Unit = ingredient.Unit
                TotalQuantity = totalQuantity
                EstimatedCost = totalQuantity * ingredient.PricePerUnit
            }

        | None ->
            {
                IngredientName = ingredientName
                Unit = "unknown"
                TotalQuantity = totalQuantity
                EstimatedCost = 0.0
            })
    |> List.sortBy (fun item -> item.IngredientName)



let shoppingListTotalCost () =
    generateShoppingList ()
    |> List.sumBy (fun item -> item.EstimatedCost)

let renderShoppingList () =
    generateShoppingList ()
    |> List.map (fun item ->
        sprintf
            """
            <div class="card shopping-item-card">
                <div class="card-header">
                    <h3>%s</h3>
                    <span>%s</span>
                </div>

                <p><strong>Total quantity needed:</strong> %.2f %s</p>
                <p><strong>Estimated cost:</strong> %s</p>
            </div>
            """
            item.IngredientName
            item.Unit
            item.TotalQuantity
            item.Unit
            (currency item.EstimatedCost))
    |> String.concat ""

let renderWeeklyMenu () =
    weeklyMenu
    |> List.map (fun menuDay ->
        sprintf
            """
            <div class="card menu-day-card">
                <div class="card-header">
                    <h3>%s</h3>
                    <span>%i portions</span>
                </div>

                <p><strong>Starter:</strong> %s</p>
                <p><strong>Main course:</strong> %s</p>
                <p><strong>Side dish:</strong> %s</p>
                <p><strong>Dessert:</strong> %s</p>

                <div class="cost-box">
                    <p><strong>Estimated day cost:</strong> %s</p>
                    <p><strong>Estimated cost per person:</strong> %s</p>
                </div>
            </div>
            """
            menuDay.DayName
            menuDay.PlannedPortions
            menuDay.Starter
            menuDay.MainCourse
            menuDay.SideDish
            menuDay.Dessert
            (currency (calculateMenuDayCost menuDay))
            (currency (calculateMenuDayCostPerPerson menuDay)))
    |> String.concat ""

let renderShoppingListSection () =
    sprintf
        """
        <section>
            <div class="section-title">
                <h2>Shopping List Generator</h2>
                <p>
                    Total weekly ingredient requirements calculated automatically
                    from the planned weekly menu.
                </p>
            </div>

            <div class="dashboard">
                <div class="stat-card">
                    <span class="stat-label">Shopping List Total Cost</span>
                    <strong>%s</strong>
                </div>
            </div>

            <div class="grid">
                %s
            </div>
        </section>
        """
        (currency (shoppingListTotalCost()))
        (renderShoppingList())

let rec renderApp () =
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

                %s

                %s

                <section>
                    <div class="section-title">
                        <h2>Weekly Menu Planner</h2>
                        <p>A five-day school kitchen menu plan with estimated costs.</p>
                    </div>
                    <div class="grid">%s</div>
                </section>

                <section>
                    <div class="section-title">
                        <h2>Ingredients</h2>
                        <p>Stock items with prices, units, categories, and suppliers.</p>
                    </div>
                    <div class="grid">%s</div>
                </section>

                <section>
                    <div class="section-title">
                        <h2>Recipes</h2>
                        <p>Each recipe calculates total cost and estimated cost per portion.</p>
                    </div>
                    <div class="grid">%s</div>
                </section>
            </div>
            """
            (renderDashboard())
            (renderIngredientForm())
            (renderShoppingListSection())
            (renderWeeklyMenu())
            (renderIngredients())
            (renderRecipes())

    connectEvents ()

and connectEvents () =
    let addButton =
        document.getElementById("add-ingredient-button") :?> HTMLButtonElement

    addButton.onclick <-
        fun _ ->
            let name = getInputValue "ingredient-name"
            let category = getInputValue "ingredient-category"
            let unit = getInputValue "ingredient-unit"
            let priceText = getInputValue "ingredient-price"
            let supplier = getInputValue "ingredient-supplier"

            match name, category, unit, tryParseFloat priceText, supplier with
            | "", _, _, _, _ ->
                window.alert("Please enter an ingredient name.")

            | _, "", _, _, _ ->
                window.alert("Please enter a category.")

            | _, _, "", _, _ ->
                window.alert("Please enter a unit.")

            | _, _, _, None, _ ->
                window.alert("Please enter a valid price.")

            | _, _, _, _, "" ->
                window.alert("Please enter a supplier.")

            | _, _, _, Some price, _ ->
                let newIngredient =
                    {
                        Name = name
                        Category = category
                        Unit = unit
                        PricePerUnit = price
                        Supplier = supplier
                    }

                ingredients <- ingredients @ [ newIngredient ]

                clearInput "ingredient-name"
                clearInput "ingredient-category"
                clearInput "ingredient-unit"
                clearInput "ingredient-price"
                clearInput "ingredient-supplier"

                renderApp ()

renderApp ()