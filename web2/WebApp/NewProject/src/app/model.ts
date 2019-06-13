export class Day{
    Id : number
    DayOfWeek : string
}
export class Line{
    Id : number
    Number : number
    Direction : string
}

export class Pricelist{
    Id : number
    From : string
    To : string
}

export class TicketPrice{
    Id : number
    Price : number
}

export class Station{
    Id : number
    Name : string
    Address: string
    X : number
    Y : number
}

export class Timetable{
    Id : number
    Info : string
}

export class TimetableInfo{
    Days: Day[];
    Lines: Line[];
}

export class TimetableType{
    Id: number
    Name: string
}