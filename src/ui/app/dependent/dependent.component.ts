import { Component, OnInit, Input } from '@angular/core';
import { Dependent } from '../shared/domain'

@Component({
  selector: 'app-dependent',
  templateUrl: './dependent.component.html',
  styleUrls: ['./dependent.component.css']
})
export class DependentComponent implements OnInit {
    @Input() dependent: Dependent

  constructor() { }

  ngOnInit() {
  }

}
