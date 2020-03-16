import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'OccupancyFilter',
    pure: false
})
export class OccupancyPipe implements PipeTransform {

    constructor(){

    }
    transform(items: any[], filter: string): any {
        if (!items || !filter) {
            return items;
        }
        // filter items array, items which match and return true will be
        // kept, false will be filtered out
        return items.filter(item => item.pg_Sharing.indexOf(filter) !== -1);
    }
}