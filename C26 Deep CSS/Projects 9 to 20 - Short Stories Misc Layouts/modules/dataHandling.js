
export class User {}

export function DataHandler(value)
{
    if (value === "" || typeof value === "number" ) {
        throw new Error("your input is empty value or number typed");   
    }
}