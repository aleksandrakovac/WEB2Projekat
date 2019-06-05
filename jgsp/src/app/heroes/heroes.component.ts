import { Component, OnInit } from '@angular/core';
import { hero } from '../hero';
import { HEROES } from '../mock-heroes';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {

  heroes = HEROES;
  selectedHero: hero;
  constructor() { }

  ngOnInit() {
  }
  onSelect(hero:hero):void 
  {
    this.selectedHero = hero;
    console.log(hero);
  }

}
