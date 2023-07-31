import { BlogModel } from "./blog-model";

export interface UserModel {
  id: number;
  username: string;
  password: string;
  firstName?: string | null;
  lastName?: string | null;
  token?: string | null;
  blogs?: BlogModel[]; 
}
