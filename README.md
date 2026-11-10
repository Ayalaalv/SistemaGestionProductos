# Sistema de Gestión de Productos

Aplicación de escritorio para administrar **categorías** y **productos** de un inventario.
Proyecto del curso **Programación II** — Universidad Internacional San Isidro Labrador (UISIL).

- Estudiante:Diego Antonio Ayala Alvanez
- Profesor:  GRANADOS LORIA JOSHUA MAURICIO
- Cuatrimestre: III Cuatrimestre 2026

---

## Funcionalidades

*Categorías*
- Agregar, modificar y eliminar categorías.
- Confirmación antes de eliminar.
- No permite eliminar una categoría que tenga productos asociados.

*Productos*
- Agregar, modificar y eliminar productos.
- Selección de categoría mediante una lista desplegable (ComboBox).
- Tabla con Id, Nombre, Precio, Stock, Fecha de registro, Categoría y Valor de inventario.
- Búsqueda de productos por nombre.
- La fecha de registro se asigna automáticamente al crear el producto.
- El valor de inventario (Precio × Stock) se calcula en el momento; no se guarda en la base de datos.

*Validaciones*
- `ErrorProvider` marca los campos vacíos o con formato incorrecto.
- Las reglas de negocio (precio mayor que cero, stock no negativo, etc.) se validan en la capa Lógica y se muestran con `MessageBox`.

---

## Tecnologías

- C# con Windows Forms (.NET 10)
- SQL Server Express
- Paquete NuGet `Microsoft.Data.SqlClient`
- Visual Studio 2026

---

## Estructura del proyecto 

| Carpeta | Responsabilidad |
|---|---|
| `Entidades` | Clases que representan los datos: `Categoria` y `Producto`. |
| `Datos` | Acceso a SQL Server: conexión y consultas (CRUD, JOIN, búsqueda). |
| `Logica` | Reglas de negocio y validaciones. Es el único puente entre la interfaz y los datos. |
| `Interfaz` | Formularios: `FrmPrincipal`, `FrmCategorias` y `FrmProductos`. |

**Flujo:** `Interfaz` → `Logica` → `Datos` → SQL Server

Los formularios no contienen lógica de negocio ni consultas SQL: solo leen los controles y llaman a la capa Lógica.

---

## Instalación y ejecución

1. Abrir **SQL Server Management Studio** y ejecutar el script de la base de datos.
   Este crea la base `GestionProductosDB`, las tablas `Categorias` y `Productos`y datos de prueba.
2. Abrir `SistemaGestionProductos.slnx` en Visual Studio.
3. Si el servidor tiene otro nombre, cambiarlo en `Datos/Conexion.cs`:
   ```
   Server=LAPTOP-20BJTKI5\SQLEXPRESS;
   ```
4. Presionar **F5** para ejecutar.

---
## GitHub:
https://github.com/Ayalaalv/SistemaGestionProductos

## Declaración de uso de Inteligencia Artificial

En este proyecto se utilizó Claude como asistente de programación de la siguiente forma:

- **Generación de código:** los formularios `FrmPrincipal`, `FrmCategorias` y `FrmProductos` y la validación con `ErrorProvider` fueron crados paso a paso con ayuda de la IA y los trabajos hecho en clase, también se usó como apoyo para escribir código de temas que aún no se habían visto en clase.
- **Base de datos:** se usó para crear el script SQL de la base de datos.
- **Explicación:** se usó para comprender mejor la arquitectura en capas y la separación de responsabilidades, con el fin de preparar la defensa.

