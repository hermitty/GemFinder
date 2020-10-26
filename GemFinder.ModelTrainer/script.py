#make_image_classifier --image_dir C:/Users/User/Desktop/images 
#--tfhub_module https://tfhub.dev/google/tf2-preview/mobilenet_v2/feature_vector/4 
#--image_size 224 --saved_model_dir C:/Users/User/Desktop/model/trained_model 
#--labels_output_file class_labels.txt --tflite_output_file new_mobile_model.tflite --summaries_dir C:/Users/User/Desktop/model

#make_image_classifier --image_dir images --tfhub_module https://tfhub.dev/google/tf2-preview/mobilenet_v2/feature_vector/4 --image_size 224 --saved_model_dir model/trained_model --labels_output_file model/trained_model/class_labels.txt --tflite_output_file model/trained_model/new_mobile_model.tflite 
#--summaries_dir my_log_dir

#script
#make_image_classifier --image_dir C:/Users/User/Desktop/images  --tfhub_module https://tfhub.dev/google/tf2-preview/mobilenet_v2/feature_vector/4 --image_size 224 --saved_model_dir C:/Users/User/Desktop/model/trained_model --labels_output_file C:/Users/User/Desktop/model/trained_model/class_labels.txt --tflite_output_file C:/Users/User/Desktop/model/trained_model/new_mobile_model.tflite 

