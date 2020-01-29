# A Kubernetes Admission Webhook sample in .NET Core 3

This is a sample that implements an Admission Webhook in k8s developed in .NET Core 3 using [Feather HTTP](https://github.com/davidfowl/FeatherHttp)

## How to build

1. Build the Docker image. From the root of the directory just type:

```
docker build -t admissionwebhook  -f AdmissionWebhook\Dockerfile . 
```

2. (If not using a local Kubernetes) Push the image to some docker registry

3. (If not using a local Kubernetes) Update the `/deploy/chart/values.yaml` to use your image

4. Deploy the chart using Helm

```
helm install admissionwebhook chart
```

## How to test

The `deploy` folder contains two pod files:

* `sample-pod.yaml`: Pod which runs nginx:latest and is rejected by the validating webhook installed
* `sample-pod2.yaml`: Pod which runs nginx:1.17.8 and is accepted by the validating webhook installed

## Notes

This code is not intended to be on production. It is just a sample of how .NET Core 3 can easily used to develop admission webhooks.
