import { BaseHttpService } from 'src/app/services/http/basehttp';



export class ValuesHttpService extends BaseHttpService<string>{
    specificUrl = "/api/values"

}