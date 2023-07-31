import { UserModel } from "./user-model";

export interface BlogModel {
    id?: number;
    title: string;
    content: string;
    summary: string;
    smallImageUrl: string;
    largeImageUrl?: string;
    userId?: number;
    user?: UserModel; 
  }