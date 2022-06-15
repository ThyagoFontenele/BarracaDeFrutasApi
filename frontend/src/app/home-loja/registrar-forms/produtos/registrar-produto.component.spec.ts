import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarProdutoComponent } from './registrar-produto.component';

describe('RegistrarProdutoComponent', () => {
  let component: RegistrarProdutoComponent;
  let fixture: ComponentFixture<RegistrarProdutoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistrarProdutoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarProdutoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
