# Fast Food Finder

## Why
This is meant as an exploratory exercise, and excuse to learn more languages.

## Gist
Given a set of fast food chains, locations, and menu prices, search and return which serve the food you want in the location you are.

## Rules
The data set should be randomly generated once, as a json, so every implementation would use the same data.

The server should load the data in memory, warm up if needed, and listen on port 8080 for an HTTP Post request, the request format will be given.

## Data Set

### Hierarchy
- Brand: 5-15
    - Location: 1-30
    - Item:  5-20 
        - Price: 1-9

### Example

*Denormalized*
``` JSON
[{
    "Brand": "Highway",
    "Location": "UK",
    "Item": "Fries",
    "Price": 1.99
}, {
    "Brand": "BertoPizza",
    "Location": "IT",
    "Item": "Pizza",
    "Price": 9.99
}]
```

### Sources

*Brands*: 
```
[
    "5Gals",
    "Andys",
    "BertosPizza",
    "BrahmsChicken",
    "BurgerQueen",
    "CFK",
    "Checkers",
    "Dandys",
    "DeutschlandDoner"
    "Drink",
    "FinitAManger",
    "GrizzlyExpress",
    "Habanero",
    "Highway",
    "Leopard",
    "Matts",
    "McTrump",
    "Moonbucks",
    "MushyKreme",
    "PapaDontPreachPizza",
    "PizzaShoe",
    "PostaCafe",
    "PumpkinDonuts",
    "TacoRing",
    "Tamari",
]
```

*Locations*
```
[
    "AD", "AE", "AF", "AG", "AI", "AL", "AM", "AO", "AQ", "AR", "AS", "AT", "AU", "AW", "AX", "AZ", "BA", "BB", "BD", "BE", 
    "BF", "BG", "BH", "BI", "BJ", "BL", "BM", "BN", "BO", "BQ", "BR", "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD", 
    "CF", "CG", "CH", "CI", "CK", "CL", "CM", "CN", "CO", "CR", "CU", "CV", "CW", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM", 
    "DO", "DZ", "EC", "EE", "EG", "EH", "ER", "ES", "ET", "FI", "FJ", "FK", "FM", "FO", "FR", "GA", "GB", "GD", "GE", "GF", 
    "GG", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS", "GT", "GU", "GW", "GY", "HK", "HM", "HN", "HR", "HT", "HU", 
    "ID", "IE", "IL", "IM", "IN", "IO", "IQ", "IR", "IS", "IT", "JE", "JM", "JO", "JP", "KE", "KG", "KH", "KI", "KM", "KN", 
    "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK", "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD", "ME", 
    "MF", "MG", "MH", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", 
    "NC", "NE", "NF", "NG", "NI", "NL", "NO", "NP", "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", 
    "PN", "PR", "PS", "PT", "PW", "PY", "QA", "RE", "RO", "RS", "RU", "RW", "SA", "SB", "SC", "SD", "SE", "SG", "SH", "SI", 
    "SJ", "SK", "SL", "SM", "SN", "SO", "SR", "SS", "ST", "SV", "SX", "SY", "SZ", "TC", "TD", "TF", "TG", "TH", "TJ", "TK", 
    "TL", "TM", "TN", "TO", "TR", "TT", "TV", "TW", "TZ", "UA", "UG", "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", 
    "VN", "VU", "WF", "WS", "YE", "YT", "ZA", "ZM", "ZW", 
]
```

*Items*
```
[
    SmallMac,
    Fries,
    Pizza,
    Milkshake,
    Donuts,
    Cronuts,
    Cola,
    CheeseBurger,
    OrangJuice,
    Salad,
    Coffee,
    Hamburger,
    Mhopper
]
```
