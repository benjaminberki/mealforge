module App

open Browser.Dom

type Ingredient =
    {
        Name: string
        Unit: string
        PricePerUnit: float
    }

type RecipeIngredient =
    {
        IngredientName: string
        Quantity: float
    }

type Recipe =
    {
        Name: string
        Ingredients: RecipeIngredient list
        Portions: int
    }

let ingredients =
    [
        {
            Name = "Chicken"
            Unit = "kg"
            PricePerUnit = 5.50
        }

        {
            Name = "Rice"
            Unit = "kg"
            PricePerUnit = 2.20
        }

        {
            Name = "Tomato"
            Unit = "kg"
            PricePerUnit = 3.10
        }
    ]

let recipes =
    [
        {
            Name = "Chicken Rice Bowl"
            Portions = 10

            Ingredients =
                [
                    {
                        IngredientName = "Chicken"
                        Quantity = 2.0
                    }

                    {
                        IngredientName = "Rice"
                        Quantity = 1.5
                    }

                    {
                        IngredientName = "Tomato"
                        Quantity = 1.0
                    }
                ]
        }
    ]

let appContainer =
    document.querySelector("#app")

let ingredientHtml =
    ingredients
    |> List.map (fun ingredient ->
        sprintf
            """
            <div class="ingredient-card">
                <h3>%s</h3>
                <p>Unit: %s</p>
                <p>Price per unit: £%.2f</p>
            </div>
            """
            ingredient.Name
            ingredient.Unit
            ingredient.PricePerUnit)
    |> String.concat ""

let recipeHtml =
    recipes
    |> List.map (fun recipe ->
        sprintf
            """
            <div class="recipe-card">
                <h2>%s</h2>
                <p>Portions: %i</p>
            </div>
            """
            recipe.Name
            recipe.Portions)
    |> String.concat ""

appContainer.innerHTML <-
    sprintf
        """
        <div class="container">
            <h1>MealForge</h1>

            <h2>Ingredients</h2>
            %s

            <h2>Recipes</h2>
            %s
        </div>
        """
        ingredientHtml
        recipeHtml
