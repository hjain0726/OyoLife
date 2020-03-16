import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'MonthlyRentFilter',
    pure: false
})
export class MonthlyRentPipe implements PipeTransform {
    constructor() {

    }
    transform(items: any[], filter: { start: number, end: number }): any {
        if (!items || !filter) {
            return items;
        }
        // filter items array, items which match and return true will be
        // kept, false will be filtered out
        return items.filter(item => item.pg_Price >= filter.start && item.pg_Price <= filter.end);
    }
}