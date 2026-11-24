# Código del episodio 01 · PrimeraApi

API de inventario en memoria con .NET 10. Es el punto de partida de la temporada de C# Claro.

[Ver el episodio «Tu primera API en C# desde cero»](https://www.youtube.com/watch?v=TziPjBWwdcU)

## Ejecutar

Desde la carpeta `PrimeraApi`:

```powershell
dotnet run
```

Escucha en `http://127.0.0.1:5077`.

## Probar

Con curl, en otra terminal:

```powershell
curl.exe -i http://127.0.0.1:5077/productos
curl.exe -i http://127.0.0.1:5077/productos/1
curl.exe -i http://127.0.0.1:5077/productos/99
'{"nombre":"Monitor","stock":4}' | curl.exe -i --json '@-' http://127.0.0.1:5077/productos
```

O abre [`peticiones.http`](PrimeraApi/peticiones.http) en VS Code con la extensión REST Client y pulsa «Send Request» sobre cada petición.

## Respuestas esperadas

| Petición | Código |
|---|---|
| `GET /` | 200 |
| `GET /productos` | 200 con la lista en JSON |
| `GET /productos/1` | 200 |
| `GET /productos/99` | 404 |
| `POST /productos` con JSON válido | 201 con encabezado `Location` |
| `POST /productos` con JSON mal formado | 400 |

## Límites conocidos (se resuelven en episodios posteriores)

- No valida los datos: acepta `stock` negativo (episodio 04).
- Los datos viven en memoria y se pierden al reiniciar (episodio 07).
- La lista no es segura para accesos simultáneos. Para esta demo con un solo usuario no importa.

## Reto del episodio

Agrega un campo `precio` al producto. Envía el precio en un `POST /productos` y comprueba que aparezca al consultar el producto creado.
