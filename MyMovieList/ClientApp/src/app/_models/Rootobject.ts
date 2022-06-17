import { Result } from "./Result";

export class RootObject{
    page!: number;
    results!: Result[];
    total_pages!: number;
    total_results!: number;
}