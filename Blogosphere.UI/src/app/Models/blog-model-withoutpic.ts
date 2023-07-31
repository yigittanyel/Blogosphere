import { UserModel } from "./user-model";

export interface BlogModelWithoutPic {
    title: string;
    content: string;
    summary: string;
    smallImageUrl: string;
    userId?: number;
    user?: UserModel; 
  }