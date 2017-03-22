// import { inject, bindable, bindingMode, View } from 'aurelia-framework';
// import 'ckeditor';

// @inject(Element)
// export class CustomTextEditor{
//     @bindable({defaultBindingMode: bindingMode.twoWay}) value;
//     @bindable name;

//     constructor(private element: Element){ }

//     updateValue(){
//         // this.value = this.textArea.value;
//     }

//     bind(owningView: View, view: View ){
//         let textArea = this.element.getElementsByTagName('textarea')[0];
//         textArea.innerText = "Balls";
//         let editor = CKEDITOR.replace(textArea);
//         // let editor = CKEDITOR.replace(this.textArea);
//         // editor.on('change', (e) => {
//         //     this.value = e.editor.getData();
//         // });
//     }
// } 