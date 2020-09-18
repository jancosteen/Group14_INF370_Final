export interface FullUser{
    id:string;
    userName:string;
    email:string; 
    password:string;
    confirmPassword:string;
    user_Name:string;
    user_Surname:string;
    user_Contact_Number:number;
    userRoleName?:string; 
    userRoleIdFk?:string; 
}