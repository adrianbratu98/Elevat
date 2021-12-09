import { EmployeeListDto } from "./employee-list-dto";

export interface AccountListDto {
    id:number,
    email:string,
    firstName: string,
    lastName: string,
    age: string,
    employee: EmployeeListDto | null
}